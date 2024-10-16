/*
    PdfAttachmentHandler - A C# program to attach files to PDFs.
    Copyright (C) 2024  Christian Reck-Würges

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

	Christian Reck-Würges
	Email: info@bloss-auktionen.de
	Paper mail: Christian Reck-Würges, Wurzelbrunnenstr.14, 79241 Ihringen, Germany
*/

using iText.Bouncycastleconnector;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Filespec;
using iText.Kernel.Utils;
using iText.Layout;
using iText.Layout.Element;
using iText.Pdfa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfAttachmentHandler
{
	/// <summary>
	/// The application´s main form.
	/// </summary>
	public partial class MainForm : Form
	{
		#region public properties
		/// <summary>
		/// Gets or sets the attachment path.
		/// </summary>
		public string AttachmentPath { get; set; }

		/// <summary>
		/// Gets or sets the PDF path.
		/// </summary>
		public string PdfPath { get; set; }
		#endregion

		#region private properties
		/// <summary>
		/// Gets or sets the displayed status text.
		/// </summary>
		private string Status { get => this.statusLabel.Text; set { this.statusLabel.Text = value; } }
		#endregion

		#region constructors and initializing
		/// <summary>
		/// Constructs a <see cref="MainForm"/> instance.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			InitializeEventWiring();
		}

		/// <summary>
		/// Wires the <see cref="Form.Shown"/> event.
		/// </summary>
		private void InitializeEventWiring()
		{
			this.Shown += MainForm_Shown;
		}
		#endregion

		#region add attachment
		/// <summary>
		/// Called when the form has been shown; starts attaching on a background thread.
		/// </summary>
		/// <param name="sender">The event´s sender; in our case, the form itself.</param>
		/// <param name="e">An <see cref="EventArgs"/> instance.</param>
		private void MainForm_Shown(object sender, EventArgs e)
		{
			this.attachmentLabel.Text = this.AttachmentPath;
			this.pdfTextLabel.Text = this.PdfPath;

			BackgroundWorker backgroundWorker = new BackgroundWorker() { WorkerReportsProgress = true };
			backgroundWorker.DoWork += BackgroundWorker_DoWork;
			backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
			backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
			backgroundWorker.RunWorkerAsync();
		}

		/// <summary>
		/// Validates the parameters and attaches the file to the PDF.
		/// </summary>
		/// <param name="sender">The event´s sender; in or case, the <see cref="BackgroundWorker"/> instance
		/// created in <see cref="MainForm_Shown"/>.</param>
		/// <param name="e">A <see cref="DoWorkEventArgs"/> instance.</param>
		private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			if (String.IsNullOrWhiteSpace(this.AttachmentPath))
			{
				e.Result = AttachmentResult.NoAttachmentFileGiven;
				return;
			}

			if (!File.Exists(this.AttachmentPath))
			{
				e.Result = AttachmentResult.AttachmentFileDoesNotExist;
				return;
			}

			if (String.IsNullOrWhiteSpace(this.PdfPath))
			{
				e.Result = AttachmentResult.NoPdfFileGiven;
				return;
			}

			if (!File.Exists(this.PdfPath))
			{
				e.Result = AttachmentResult.PdfFileDoesNotExist;
				return;
			}

			string tempFilename = GetTempFilename(this.PdfPath);
			using (PdfReader reader = new PdfReader(this.PdfPath))
			using (PdfWriter writer = new PdfWriter(tempFilename))
			{
				PdfADocument targetDocument = new PdfADocument(reader, writer);

				PdfDictionary parameters = new PdfDictionary();
				parameters.Put(PdfName.ModDate, new PdfDate().GetPdfObject());
				parameters.Put(PdfName.F, new PdfString("invoice.xml"));
				parameters.Put(PdfName.UF, new PdfString("invoice.xml", PdfEncodings.UNICODE_BIG));
				PdfFileSpec fileSpec =
					PdfFileSpec.CreateEmbeddedFileSpec
					(
						targetDocument,
						this.AttachmentPath,
						"",
						"invoice.xml",
						PdfName.Alternative,
						parameters,
						PdfName.Data
					);
				targetDocument.AddFileAttachment("invoice.xml", fileSpec);
				PdfArray array = new PdfArray() { fileSpec.GetPdfObject().GetIndirectReference() };
				targetDocument.GetCatalog().Put(PdfName.AF, array);

				targetDocument.Close();
			}

			File.Delete(this.PdfPath);
			File.Move(tempFilename, this.PdfPath);

			e.Result = AttachmentResult.AttachmentAdded;
		}

		/// <summary>
		/// Called when the background worker reports progress; sets the status text accordingly.
		/// </summary>
		/// <param name="sender">The event´s sender; in or case, the <see cref="BackgroundWorker"/> instance
		/// created in <see cref="MainForm_Shown"/>.</param>
		/// <param name="e">A <see cref="ProgressChangedEventArgs"/> instance.</param>
		private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.Status = (e.UserState == null) ? "" : e.UserState.ToString();
		}

		/// <summary>
		/// Called when the background worker has finished; clears the status text and closes the form.
		/// </summary>
		/// <param name="sender">The event´s sender; in or case, the <see cref="BackgroundWorker"/> instance
		/// created in <see cref="MainForm_Shown"/>.</param>
		/// <param name="e">A <see cref="RunWorkerCompletedEventArgs"/> instance.</param>
		private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Status = "";
			this.Close();
		}
		#endregion

		#region helper methods
		private string GetTempFilename(string originalFilename)
		{
			Int64 ordinal = 1;
			string result = GetTempFilename(originalFilename, ordinal);
			while (File.Exists(result))
			{
				ordinal++;
				result = GetTempFilename(originalFilename, ordinal);
			}
			return result;
		}

		private string GetTempFilename(string originalFilename, Int64 ordinal) =>
			originalFilename.Replace
			(
				Path.GetFileNameWithoutExtension(originalFilename),
				String.Format
				(
					CultureInfo.InvariantCulture,
					"{0} ({1})",
					Path.GetFileNameWithoutExtension(originalFilename),
					ordinal
				)
			);
		#endregion
	}
}
