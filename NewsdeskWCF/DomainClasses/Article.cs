using System;
using System.Collections.Generic;

using System.Runtime.Serialization;

namespace DomainClasses
{
	[DataContract]
	public class Article
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Preamble { get; set; }

		[DataMember]
		public string ArticleBody { get; set; }

		[DataMember]
		public DateTime CreatedDate { get; set; }

		[DataMember]
		public DateTime UpdatedDate { get; set; }

		[DataMember]
		public DateTime? PublishDate { get; set; }

		[DataMember]
		public bool IsApproved { get; set; }

		[DataMember]
		public virtual ICollection<Author> Authors { get; set; }

		[DataMember]
		public virtual ICollection<Category> Categories { get; set; }

		public Article()
		{
			Authors = new HashSet<Author>();
			Categories = new HashSet<Category>();
		}
	}
}