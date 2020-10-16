using System;

namespace DV_10132020_EN_INTERFACES
{
	public class BankResult
	{
		/// <summary>
		/// The Bank home currency
		/// </summary>
		public string HomeCurrency { get; set; }

		/// <summary>
		/// Exchange rate is stated in units of foreign currency per one unit of home currency
		/// </summary>
		public decimal ExchangeRate { get; set; }

		/// <summary>
		/// Observation Date
		/// </summary>
		public DateTime RateDate { get; set; }

		/// <summary>
		/// Name of the Bank providing observation
		/// </summary>
		public string BankName { get; set; }
	}
}