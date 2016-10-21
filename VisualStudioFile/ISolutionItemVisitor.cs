using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioFile
{
	interface ISolutionItemVisitor
	{
		void Visit(CSharpProject project);
		void Visit(CppProject project);
	}
}
