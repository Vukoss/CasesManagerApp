using System;
using CaseManagerLibrary.Models;

namespace CasesManager.Model
{
	public class IssueCommentModel
	{
		public IssueCommentModel()
		{
			Issue = new();
			Comment = new();
		}
		public DisplayIssueModel Issue { get; set; }

		public DisplayCommentModel Comment { get; set; }
	}
}

