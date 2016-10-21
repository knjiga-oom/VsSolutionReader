using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualStudioFile;

namespace ConcertoVersionFactory
{
	class Program
	{
		static void Main(string[] args)
		{
			Solution s = new Solution(@"D:\Projects\AVL\Concerto_V50\Concerto_V50\All\FilePlugins.sln");
			s.Accept(new RcFileVisitor());
		}
	}
}
