using System;
using System.Collections.Generic;
using System.Text;

namespace VisualStudioFile
{
	enum SolutionItemType
	{
		SolutionFolder,
		CSharpProject,
		CppProject
	}

	static class SolutionItemFactory
	{
		public static SolutionItem Create(Guid typeGuid, string name, string filename, Guid projectId)
		{
			SolutionItemType sit = SolutionTypeGuids[typeGuid];
			switch (sit)
			{
				case SolutionItemType.SolutionFolder:
					return new SolutionFolder(name, filename, projectId, typeGuid);
				case SolutionItemType.CSharpProject:
					return new CSharpProject(name, filename, projectId, typeGuid);
				case SolutionItemType.CppProject:
					return new CppProject(name, filename, projectId, typeGuid);
				default:
					return new UnknownProject(name, filename, projectId, typeGuid);
			}
		}

		public static readonly Dictionary<Guid, SolutionItemType> SolutionTypeGuids = new Dictionary<Guid, SolutionItemType>
		{
			{ new Guid("{2150E333-8FDC-42A3-9474-1A3956D46DE8}"), SolutionItemType.SolutionFolder },
			{ new Guid("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"), SolutionItemType.CSharpProject },
			{ new Guid("{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}"), SolutionItemType.CppProject }
		};
	}
}
