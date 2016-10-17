using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace DomainClasses
{
	[DataContract]
	public class Mail
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public virtual ICollection<Author> Emails { get; set; }
		[DataMember]
		public string Subject { get; set; }
		[DataMember]
		public string Body { get; set; }
		[DataMember]
		public bool isBodyHtml { get; set; }
		public Mail()
		{
			Emails = new HashSet<Author>();
		
		}
	}
}