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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfAttachmentHandler
{
	internal static class Program
	{
		/// <summary>
		/// The application´s main entry point. The method validates the command line arguments and opens a <see cref="MainForm"/> instance.
		/// </summary>
		/// <param name="args">The command line arguments.</param>
		[STAThread]
		static void Main(string[] args)
		{
			if
			(
				(args == null) ||
				(args.Length < 2) ||
				(!GetFilename(args, PdfAttachmentHandler_res.attachment_path_prefix, out string attachmentPath)) ||
				(!GetFilename(args, PdfAttachmentHandler_res.pdf_path_prefix, out string pdfPath))
			)
			{
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm() { AttachmentPath = attachmentPath, PdfPath = pdfPath });
		}

		/// <summary>
		/// Finds the argument starting with the give prefix, extracts the filename and checks if the file exists.
		/// </summary>
		/// <param name="args">The command line arguments.</param>
		/// <param name="prefix">A prefix string.</param>
		/// <param name="filename">The filename extracted from the argument.</param>
		/// <returns>True if and only if the argument was found and the file exists.</returns>
		private static bool GetFilename(string[] args, string prefix, out string filename)
		{
			filename = null;
			if (String.IsNullOrWhiteSpace(prefix))
			{
				return false;
			}

			string argumentString = args.FirstOrDefault(arg => (arg.Trim().Replace(" ", "").IndexOf(prefix, StringComparison.Ordinal) == 0));
			if (argumentString == null)
			{
				return false;
			}

			filename = argumentString.Substring(argumentString.IndexOf('=') + 1).Trim().Replace("%%space%%", " ");
			return File.Exists(filename);
		}
	}
}
