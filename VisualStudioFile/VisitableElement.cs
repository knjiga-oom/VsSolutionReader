using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioFile
{
	abstract class VisitableElement
	{
		public abstract void Accept(ISolutionItemVisitor visitor);
	}
}
