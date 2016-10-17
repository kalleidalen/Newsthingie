using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DomainClasses
{
	[DataContract]
	public class AuthorToClient
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
		public bool IsEditor { get; set; }
		[DataMember]
		public bool IsApproved { get; set; }
		[DataMember]
		public bool IsSelected { get; set; }
		[DataMember]
		
		public string FullName
		{
			get { return FirstName + " " + LastName;}
			set { FullName = value; }
		}
		
		
		public AuthorToClient()
		{
			
		
		}
				

	}
}
