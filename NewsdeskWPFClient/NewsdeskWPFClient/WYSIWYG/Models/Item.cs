using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsdeskWPFClient.WYSIWYG.Models
{
	public class Item
	{
		public Item()
		{ }

		public Item(string id, string value)
		{
			this.Value = value;
			this.Id = id;
		}
		public string Id { get; set; }
		public string Value { get; set; }
	}
}
