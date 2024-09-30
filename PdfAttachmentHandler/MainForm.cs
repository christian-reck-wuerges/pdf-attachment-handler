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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
		public string AttachmentPath { get => this.attachmentLabel.Text; set { this.attachmentLabel.Text = value; } }

		/// <summary>
		/// Gets or sets the PDF path.
		/// </summary>
		public string PdfPath { get => this.pdfLabel.Text; set { this.pdfLabel.Text = value; } }
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

		private void InitializeEventWiring()
		{
			this.Shown += MainForm_Shown;
		}
		#endregion

		private void MainForm_Shown(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
