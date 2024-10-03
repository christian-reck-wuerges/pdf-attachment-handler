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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfAttachmentHandler
{
	internal enum AttachmentResult
	{
		NoAttachmentFileGiven, AttachmentFileDoesNotExist, NoPdfFileGiven, PdfFileDoesNotExist, AttachmentAdded
	}
}
