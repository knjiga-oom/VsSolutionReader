using System;
using System.IO;
using System.Linq;

namespace VisualStudioFile
{
	class RcFileVisitor : ISolutionItemVisitor
	{
		public void Visit(CppProject project)
		{
			ProjectItem found = project.Items.FirstOrDefault(pi => Path.GetExtension(pi.Filename) == ".rc");
			if (found != null)
				ModifyResourceFile(found);
			else
				CreateResourceFile();
		}

		public void Visit(CSharpProject project)
		{
			throw new NotImplementedException();
		}

		private void ModifyResourceFile(ProjectItem projectItem)
		{

		}

		private ProjectItem CreateResourceFile()
		{
			return null;
		}
	}
}
