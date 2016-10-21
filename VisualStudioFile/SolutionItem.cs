using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioFile
{
	abstract class SolutionItem : VisitableElement
	{
		protected SolutionItem(string name, string filename, Guid projectId, Guid projectType)
		{
			Name = name;
			Filename = filename;
			ProjectId = projectId;
			ProjectType = projectType;
		}

		// for testing purposes only
		protected SolutionItem(string filename)
		{
			Filename = filename;
		}

		public readonly string Name;
		public readonly string Filename;
		public readonly Guid ProjectId;
		public readonly Guid ProjectType;
	}
}
