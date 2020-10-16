using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DV_10132020_EN_INTERFACES
{
	public interface IBank
	{
		Dictionary<string, string> SupportedCurrencies { get; }
		Task<BankResult> GetRateAsync(string currency, DateTime date);
	}
}