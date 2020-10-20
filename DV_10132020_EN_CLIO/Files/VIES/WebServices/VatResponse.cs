using System;
using System.Runtime.Serialization;

namespace VIES
{
	[Serializable]
	[DataContract]
	public class VatResponse
	{
		[DataMember(Name ="valid", EmitDefaultValue = true)]
		public bool IsValid { get; set; }
		
		[DataMember(Name = "address", EmitDefaultValue = true)]
		public string Address { get; set; }
		
		[DataMember(Name = "countryCode", EmitDefaultValue = true)]
		public string CountryCode { get; set; }
		
		[DataMember(Name = "name", EmitDefaultValue = true)]
		public string Name { get; set; }
		
		[DataMember(Name = "requestDate", EmitDefaultValue = true)]
		public DateTime RequestDate { get; set; }
		
		[DataMember(Name = "vatNumber", EmitDefaultValue = true)]
		public string VatNumber { get; set; }
	}
}