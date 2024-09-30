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

namespace PdfAttachmentHandler
{
	partial class MainForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.attachmentTextLabel = new System.Windows.Forms.Label();
			this.attachmentLabel = new System.Windows.Forms.Label();
			this.pdfLabel = new System.Windows.Forms.Label();
			this.pdfTextLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.statusTextLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// attachmentTextLabel
			// 
			this.attachmentTextLabel.AutoSize = true;
			this.attachmentTextLabel.Location = new System.Drawing.Point(12, 9);
			this.attachmentTextLabel.Name = "attachmentTextLabel";
			this.attachmentTextLabel.Size = new System.Drawing.Size(80, 13);
			this.attachmentTextLabel.TabIndex = 0;
			this.attachmentTextLabel.Text = "Attachment file:";
			// 
			// attachmentLabel
			// 
			this.attachmentLabel.AutoSize = true;
			this.attachmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.attachmentLabel.Location = new System.Drawing.Point(98, 9);
			this.attachmentLabel.Name = "attachmentLabel";
			this.attachmentLabel.Size = new System.Drawing.Size(0, 13);
			this.attachmentLabel.TabIndex = 1;
			// 
			// pdfLabel
			// 
			this.pdfLabel.AutoSize = true;
			this.pdfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pdfLabel.Location = new System.Drawing.Point(98, 26);
			this.pdfLabel.Name = "pdfLabel";
			this.pdfLabel.Size = new System.Drawing.Size(0, 13);
			this.pdfLabel.TabIndex = 3;
			// 
			// pdfTextLabel
			// 
			this.pdfTextLabel.AutoSize = true;
			this.pdfTextLabel.Location = new System.Drawing.Point(12, 26);
			this.pdfTextLabel.Name = "pdfTextLabel";
			this.pdfTextLabel.Size = new System.Drawing.Size(47, 13);
			this.pdfTextLabel.TabIndex = 2;
			this.pdfTextLabel.Text = "PDF file:";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.Location = new System.Drawing.Point(98, 43);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(0, 13);
			this.statusLabel.TabIndex = 5;
			// 
			// statusTextLabel
			// 
			this.statusTextLabel.AutoSize = true;
			this.statusTextLabel.Location = new System.Drawing.Point(12, 43);
			this.statusTextLabel.Name = "statusTextLabel";
			this.statusTextLabel.Size = new System.Drawing.Size(40, 13);
			this.statusTextLabel.TabIndex = 4;
			this.statusTextLabel.Text = "Status:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(546, 65);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.statusTextLabel);
			this.Controls.Add(this.pdfLabel);
			this.Controls.Add(this.pdfTextLabel);
			this.Controls.Add(this.attachmentLabel);
			this.Controls.Add(this.attachmentTextLabel);
			this.Name = "MainForm";
			this.Text = "PdfAttachmentHandler";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label attachmentTextLabel;
		private System.Windows.Forms.Label attachmentLabel;
		private System.Windows.Forms.Label pdfLabel;
		private System.Windows.Forms.Label pdfTextLabel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label statusTextLabel;
	}
}

