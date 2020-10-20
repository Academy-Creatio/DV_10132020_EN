using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Terrasoft.Common;
using VIES;

namespace DV_10132020_EN_CLIO.VIES
{
	public class ValidateVat
	{
		#region Properties
		private Dictionary<string, string> MemberStates { get; set; } = new Dictionary<string, string>
		{
			{"AT","Austria" },
			{"BE","Belgium" },
			{"BG","Bulgaria" },
			{"CY","Cyprus" },
			{"CZ","Czech Republic" },
			{"DE","Germany" },
			{"DK","Denmark" },
			{"EE","Estonia" },
			{"EL","Greece" },
			{"ES","Spain" },
			{"FI","Finland" },
			{"FR","France" },
			{"GB","United Kingdom" },
			{"HR","Croatia" },
			{"HU","Hungary" },
			{"IE","Ireland" },
			{"IT","Italy" },
			{"LT","Lithuania" },
			{"LU","Luxembourg" },
			{"LV","Latvia" },
			{"NL","The Netherlands" },
			{"PL","Poland" },
			{"PT","Portugal" },
			{"RO","Romania" },
			{"SE","Sweden" },
			{"SI","Slovenia" },
			{"SK","Slovakia" }
		};
		public VatResponse Result { get; set; } = new VatResponse();
		#endregion

		#region Methods : Public
		public VatResponse Validate(string vat)
		{
			if (string.IsNullOrEmpty(vat)) return Result;
			if (vat.Length < 8) return Result;
			if (!IsValidString(vat, out string NationalPrefix, out string VatNumber)) return Result;

			BasicHttpsBinding binding = new BasicHttpsBinding();
			EndpointAddress endPointAddress = new EndpointAddress("https://ec.europa.eu/taxation_customs/vies/services/checkVatService");
			var client = new checkVatPortTypeClient(binding, endPointAddress);

			Task.Run(async () =>
			{
				checkVatResponse result = await client.checkVatAsync(NationalPrefix, VatNumber);
				if (result.Body.valid)
				{
					Result.IsValid = result.Body.valid;
					Result.Name = result.Body.name;

					if (!string.IsNullOrEmpty(result.Body.address) && result.Body.address != "---")
					{
						string addr = result.Body.address;
						while (addr.Contains("\n"))
						{
							addr = addr.Replace("\n", " ");
						}
						addr = Regex.Replace(addr, @"\s+", " ");
						Result.Address = addr;
					}
					
					Result.CountryCode = result.Body.countryCode;
					Result.RequestDate = DateTime.Parse(result.Body.requestDate);
					Result.VatNumber = result.Body.vatNumber;
				}
			}).Wait();
			if (!Result.IsValid)
			{
				Result.IsValid = false;
				Result.RequestDate = DateTime.Now;
				Result.Name = "";
				Result.CountryCode = NationalPrefix;
				Result.VatNumber = $"{NationalPrefix}{VatNumber}";
			}
			return Result;
		}
		#endregion

		#region Methods : Private
		/// <summary>
		/// Validated VAT Number against known RegEx
		/// <see cref="https://www.gov.uk/guidance/vat-eu-country-codes-vat-numbers-and-vat-in-other-languages"/>
		/// </summary>
		/// <param name="nationalPrefix">Member states country code</param>
		/// <returns>RegEx String</returns>
		private static string GetRegExForNationalPrefiX(string nationalPrefix)
		{
			switch (nationalPrefix)
			{
				case "AT":
					//One letter and eight digits. The first character is always 'U'
					return @"[U]\d{8}";
				case "BE":
					//Nine digits
					return @"[0]\d{9}";
				case "BG":
					return @"\d{9,10}";
				case "CY":
					//Eight digits and one letter, Last character is always a letter
					return @"\d{8}[a-zA-Z]";
				case "CZ":
					//	Eight digits or Nine digits or Ten digits
					// Where 11, 12 or 13 digit numbers are quoted, 
					// delete the first three digits (as these are a tax code)
					return @"\d{8,10}";

				case "HR":
					return @"\d{11}";

				case "FI":
				case "DK":
				case "HU":
				case "LU":
				case "MT":
				case "SI":
					//Eight digits
					return @"\d{8}";

				case "DE":
				case "EE":
				case "PT":
					//Nine digits
					return @"\d{9}";

				case "FR":
					//Eleven digits or Ten digits and one letter or Nine digits and two letters
					//May include 1 or 2 letters :-Either FIRST, SECOND or FIRST &SECOND.
					// All letters except O and I are valid.
					return @"[^=\sOoIi]{2}\d{9}|[^=\sOoIi]\d{10}|\d{11}";

				case "EL":
					//Nine digits, Prefix any 8 digit number with zero
					return @"[0]\d{8}";

				case "IE":
					//	Seven digits and one letter or Six digits and two letters
					//Includes 1 or 2 letters :- Either LAST or SECOND &LAST
					return @"\d{7}[a-zA-Z]|\d[a-zA-Z]\d{5}[a-zA-Z]";

				case "IT":
				case "LV":
					//Eleven digits
					return @"\d{11}";
				case "LT":
					//nine or twelve digits
					return @"\d{9}|\d{12}";
				case "NL":
					//Eleven digits and one letter
					//Tenth character is always 'B' The 3 digit suffix is always B01 to B99.
					return @"\d{9}[bB]\d{2}";
				case "PL":
				case "SK":
					//Ten digits
					return @"\d{10}";
				case "ES":
					//Eight digits and one letter or Seven digits and two letters
					//Includes 1 or 2 letters :- Either FIRST, LAST or FIRST &LAST.
					return @"\d{8}\w|\w\d{7}\w";

				case "SE":
					//Twelve digits, The last 2 characters must be '01'
					return @"\d{10}[0][1]";

				case "GB":
					// Nine digits or Twelve digits
					// Twelve digits if the number represents a sub-company within a group
					return @"\d{9}|\d{12}";
				default:
					return string.Empty;
			}
		}

		/// <summary>
		/// Validate Vat String against known RegEx
		/// https://www.iecomputersystems.com/ordering/eu_vat_numbers.htm
		/// </summary>
		/// <param name="vatId"></param>
		/// <returns></returns>
		private bool IsValidString(string vatId, out string NationalPrefix, out string VatNumber)
		{
			string nationalPrefix = string.Empty;
			string vatNumber = string.Empty;
			
			//MIN VatId is 2 chars for National Prefix + 8 chars= 10 chars
			vatId = vatId.Trim().Replace(" ", "");
			if (vatId.Length >= 10)
			{
				nationalPrefix = vatId.Substring(0, 2);
				vatNumber = vatId.Substring(2, vatId.Length - 2);
			}
			if(MemberStates.ContainsKey(nationalPrefix))
			{
				string regex = GetRegExForNationalPrefiX(nationalPrefix);
				Regex regEx = new Regex(regex);
				if (regEx.Match(vatNumber).Value == vatNumber)
				{
					NationalPrefix = nationalPrefix;
					VatNumber = vatNumber;
					return true;
				}
			}
			NationalPrefix = nationalPrefix;
			VatNumber = vatNumber;
			return false;
		}
		#endregion
	}
}
