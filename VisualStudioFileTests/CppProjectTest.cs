using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisualStudioFile;

namespace VisualStudioFileTests
{
	[TestClass]
	public class CppProjectTest
	{
		[TestMethod]
		public void CppProject_Items_ReturnsListOfAllCompileItems()
		{
			TextResourceReader trr = new TextResourceReader("VisualStudioFileTests.Resources.SomeCppProject.vcxproj");
			CppProject project = new CppProject(trr);
			Assert.AreEqual(11, project.Items.Count());
		}
	}
}
