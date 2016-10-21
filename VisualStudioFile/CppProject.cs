using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VisualStudioFile
{
	class CppProject : Project
	{
		public CppProject(string name, string filename, Guid projectId, Guid projectType)
			: base(name, filename, projectId, projectType)
		{
		}

		// for testing purposes only
		public CppProject(TextReader reader, string filename = "")
			: base(reader, filename) { }

		public override void Accept(ISolutionItemVisitor visitor)
		{
			visitor.Visit(this);
		}

		protected override IEnumerable<string> ItemXPaths
		{
			get
			{
				return new string[] { CompileItemXPath, IncludeItemXPath, ResourceItemXPath, NoneItemXPath };
			}
		}

		private const string CompileItemXPath = "/ms:Project/ms:ItemGroup/ms:ClCompile/@Include";
		private const string IncludeItemXPath = "/ms:Project/ms:ItemGroup/ms:ClInclude/@Include";
		private const string ResourceItemXPath = "/ms:Project/ms:ItemGroup/ms:ResourceCompile/@Include";
		private const string NoneItemXPath = "/ms:Project/ms:ItemGroup/ms:None/@Include";
	}
}
