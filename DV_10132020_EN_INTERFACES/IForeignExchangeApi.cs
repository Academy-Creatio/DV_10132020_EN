using System;

namespace DV_10132020_EN_INTERFACES
{
	public interface IForeignExchangeApi
	{
		BankResult GetEcbRate(string currency, DateTime date);
		BankResult GetBOCRate(string currency, DateTime date);
	}
}
