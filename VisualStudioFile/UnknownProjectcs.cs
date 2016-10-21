using System;
using System.Collections.Generic;
using System.Text;

namespace VisualStudioFile
{
	class UnknownProject : Project
	{
		public UnknownProject(string name, string filename, Guid projectId, Guid projectType)
			: base(name, filename, projectId, projectType) { }

		public override void Accept(ISolutionItemVisitor visitor) { }
		protected override IEnumerable<string> ItemXPaths
		{
			get
			{
				return new string[0];
			}
		}
	}
}
