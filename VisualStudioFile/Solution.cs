using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VisualStudioFile
{
	class Solution : VisitableElement
	{
		public Solution(TextReader reader, string filename = "")
		{
			Filename = filename;
			Parse(reader);
		}

		public Solution(string filename)
		{
			Filename = filename;
			using (StreamReader sr = new StreamReader(filename))
				Parse(sr);
		}

		public override void Accept(ISolutionItemVisitor visitor)
		{
			foreach (SolutionItem item in items)
				item.Accept(visitor);
		}

		public IEnumerable<SolutionItem> Items
		{
			get { return items; }
		}

		private void Parse(TextReader reader)
		{
			string solutionRoot = GetSolutionRoot();
			Regex regex = new Regex(ProjectPattern);
			string input = reader.ReadToEnd();
			foreach (Match match in regex.Matches(input))
			{
				Guid typeGuid = new Guid(match.Groups["typeGuid"].Value);
				string name = match.Groups["name"].Value;
				string filename = match.Groups["filename"].Value;
				Guid projectGuid = new Guid(match.Groups["projectGuid"].Value);
				filename = Path.Combine(solutionRoot, filename);
				SolutionItem si = SolutionItemFactory.Create(typeGuid, name, filename, projectGuid);
				items.Add(si);
			}
		}

		private string GetSolutionRoot()
		{
			if (Filename.Length == 0)
				return string.Empty;
			return Path.GetDirectoryName(Filename);
		}

		public readonly string Filename;

		private List<SolutionItem> items = new List<SolutionItem>();

		private const string GuidPattern = "\\{[0-9a-fA-F]{8}(-[0-9a-fA-F]{4}){3}-[0-9a-fA-F]{12}\\}";
		private const string ProjectPattern = "Project\\(\\\"(?<typeGuid>" + GuidPattern + ")\\\"\\)\\s*=\\s*\\\"(?<name>.+)\\\",\\s" +
											  "\\\"(?<filename>.+)\\\",\\s* \\\"(?<projectGuid>" + GuidPattern + ")\\\"\\s*EndProject";
	}
}
