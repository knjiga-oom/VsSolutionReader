using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VisualStudioFile
{
    class CSharpProject : Project
    {
        public CSharpProject(string name, string filename, Guid projectId, Guid projectType)
			: base(name, filename, projectId, projectType) { }

		// for testing purposes only
		public CSharpProject(TextReader reader, string filename = "")
			: base(reader, filename) { }

		public override void Accept(ISolutionItemVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
