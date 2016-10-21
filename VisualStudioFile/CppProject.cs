using System;
using System.Collections.Generic;
using System.Text;

namespace VisualStudioFile
{
	class CppProject : Project
	{
		public CppProject(string name, string filename, Guid projectId, Guid projectType)
			: base(name, filename, projectId, projectType)
		{
		}

		public override void Accept(IVisitor visitor) { }
	}
}
