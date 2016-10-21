using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VisualStudioFile;

namespace VisualStudioFileTests
{
    [TestClass]
    public class SolutionTest
    {
        [TestMethod]
        public void Solution_GetProjects_ReturnsCollectionOfProjectsInSolution()
        {
            TextResourceReader trr = new TextResourceReader("VisualStudioFileTests.Resources.ComplexApplication.sln");
            Solution sr = new Solution(trr);
            Assert.AreEqual(6, sr.Items.Count());
            Assert.AreEqual("WpfApplication1", sr.Items.First().Name);
            Assert.AreEqual("ConsoleApplication1", sr.Items.Last().Name);
        }
    }
}
