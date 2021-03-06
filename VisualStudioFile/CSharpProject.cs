﻿using System;
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

		protected override IEnumerable<string> ItemXPaths
		{
			get
			{
				return new string[] { CompileIncludeXPath, PageIncludeXPath };
			}
		}

		private const string CompileIncludeXPath = "/ms:Project/ms:ItemGroup/ms:Compile/@Include";
		private const string PageIncludeXPath = "/ms:Project/ms:ItemGroup/ms:Page/@Include";

	}
}
