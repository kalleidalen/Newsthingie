using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DomainClasses
{
	[DataContract]
	public class Category
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public virtual ICollection<Subscriber> Subscribers { get; set; }

		[DataMember]
		public virtual ICollection<Article> Articles { get; set; }

		public Category()
		{
			Subscribers = new HashSet<Subscriber>();
			Articles = new HashSet<Article>();
		}
	}
}