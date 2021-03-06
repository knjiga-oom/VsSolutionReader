﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisualStudioFile;

namespace VisualStudioFileTests
{
	[TestClass]
	public class CSharpProjectTest
	{
		[TestMethod]
		public void CSharpProject_Items_ReturnsListOfAllCompileItems()
		{
			TextResourceReader trr = new TextResourceReader("VisualStudioFileTests.Resources.WpfApplication1.csproj");
			CSharpProject project = new CSharpProject(trr);
			Assert.AreEqual(6, project.Items.Count());
		}

		[TestMethod]
		public void CSharpProject_Items_ContainActualFilenames()
		{
			TextResourceReader trr = new TextResourceReader("VisualStudioFileTests.Resources.WpfApplication1.csproj");
			CSharpProject project = new CSharpProject(trr, @"C:\Projects\WpfApplication1.csproj");
			ProjectItem first = project.Items.First();
			Assert.AreEqual(@"C:\Projects\App.xaml.cs", first.Filename);
			ProjectItem last = project.Items.Last();
			Assert.AreEqual(@"C:\Projects\MainWindow.xaml", last.Filename);
		}
	}
}
