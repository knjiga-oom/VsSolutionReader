using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace VisualStudioFile
{
	abstract class Project : SolutionItem
	{
		protected Project(string name, string filename, Guid projectId, Guid projectType)
			: base(name, filename, projectId, projectType)
		{
		}

		// for testing purposes only
		protected Project(TextReader reader, string filename) : base(filename)
		{
			Parse(reader);
		}

		private void Parse(TextReader reader)
		{
			items = new List<ProjectItem>();

			XPathDocument document = new XPathDocument(reader);
			XPathNavigator navigator = document.CreateNavigator();

			XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
			manager.AddNamespace(NamespacePrefix, "http://schemas.microsoft.com/developer/msbuild/2003");

			Parse(navigator, manager, CompileIncludeXPath);
			Parse(navigator, manager, PageIncludeXPath);
		}

		private void Parse(XPathNavigator navigator, XmlNamespaceManager manager, string xpath)
		{
			string projectRoot = GetProjectRoot();

			XPathExpression expression = navigator.Compile(xpath);
			expression.SetContext(manager);
			XPathNodeIterator ni = navigator.Select(expression);
			while (ni.MoveNext())
			{
				string filename = Path.Combine(projectRoot, ni.Current.Value);
				items.Add(new CompileItem(filename));
			}
		}

		public IEnumerable<ProjectItem> Items
		{
			get
			{
				if (items == null)
				{
					using (StreamReader reader = new StreamReader(Filename))
						Parse(reader);
				}
				return items;
			}
		}

		private string GetProjectRoot()
		{
			if (Filename.Length == 0)
				return string.Empty;
			return Path.GetDirectoryName(Filename);
		}

		private List<ProjectItem> items;

		private const string NamespacePrefix = "ms";
		private const string CompileIncludeXPath = "/ms:Project/ms:ItemGroup/ms:Compile/@Include";
		private const string PageIncludeXPath = "/ms:Project/ms:ItemGroup/ms:Page/@Include";
	}
}
