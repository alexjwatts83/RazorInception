using System.Collections.Generic;

namespace RazorInception.Domain.Entities
{
	public class TodoList
	{
		public int Id { get; set; }
		public IEnumerable<TodoItem> Items { get; set; }
	}
}
