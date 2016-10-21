using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioFile
{
	interface IVisitor
	{
		void Visit(CSharpProject project);
	}
}
