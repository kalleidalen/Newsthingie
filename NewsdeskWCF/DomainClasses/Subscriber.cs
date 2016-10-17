using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DomainClasses
{
	[DataContract]
	public class Subscriber 
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public virtual ICollection<Category> Categories { get; set; }

		public Subscriber()
		{
			Categories = new List<Category>();
		}
	}
}