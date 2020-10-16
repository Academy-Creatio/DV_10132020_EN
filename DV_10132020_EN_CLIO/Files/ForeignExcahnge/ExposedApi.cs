using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DV_10132020_EN_INTERFACES;
using ForeignExchange;
using Terrasoft.Common;
using Terrasoft.Core.Factories;

namespace ForeignExcahnge
{
	[DefaultBinding(typeof(IForeignExchangeApi))]
	public class ExposedApi : IForeignExchangeApi
	{
		public DV_10132020_EN_INTERFACES.BankResult GetBOCRate(string currency, DateTime date)
		{
			var BOC = BankFactory.GetBank(BankFactory.SupportedBanks.BOC);
			IBankResult BocResult = BOC.GetRateAsync(currency, date).Result;

			DV_10132020_EN_INTERFACES.BankResult result = new DV_10132020_EN_INTERFACES.BankResult();

			result.BankName = BocResult.BankName;
			result.ExchangeRate = BocResult.ExchangeRate;
			result.RateDate = BocResult.RateDate;
			result.HomeCurrency = BocResult.HomeCurrency;
			return result;
		}


		DV_10132020_EN_INTERFACES.BankResult IForeignExchangeApi.GetEcbRate(string currency, DateTime date)
		{
			var ECB = BankFactory.GetBank(BankFactory.SupportedBanks.ECB);
			IBankResult EcbResult = ECB.GetRateAsync(currency, date).Result;

			DV_10132020_EN_INTERFACES.BankResult result = new DV_10132020_EN_INTERFACES.BankResult();

			result.BankName = EcbResult.BankName;
			result.ExchangeRate = EcbResult.ExchangeRate;
			result.RateDate = EcbResult.RateDate;
			result.HomeCurrency = EcbResult.HomeCurrency;
			return result;
		}
	}
}
