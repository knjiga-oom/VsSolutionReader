using System;
using System.Collections.Generic;
using System.Text;

namespace VisualStudioFile
{
    class ProjectItem
    {
		public ProjectItem(string filename)
		{
			Filename = filename;
		}

		public readonly string Filename;
	}
}
