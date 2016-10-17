using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DomainClasses
{
	[DataContract]
	public class Author
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string FirstName { get; set; }
		[DataMember]
		public string LastName { get; set; }
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public string Password { get; set; }
		[DataMember]
		public bool IsEditor { get; set; }
		[DataMember]
		public bool IsApproved { get; set; }
		[DataMember]
		public virtual ICollection<Article> Articles { get; set; }
		public virtual ICollection<Mail> Emails { get; set; }
		public Author()
		{

			Articles = new HashSet<Article>();
			Emails = new HashSet<Mail>();
		}
				

	}
}
