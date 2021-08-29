using System.Collections.Generic;

namespace RazorInception.Domain.Entities
{
	public class TodoList
	{
		public IEnumerable<TodoItem> Items { get; set; }
	}
}
