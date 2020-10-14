using DV_10132020_EN_INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrasoft.Core.Factories;

namespace DV_10132020_EN_CLIO
{
	[DefaultBinding(typeof(Ihelper1))]
	public class helper1 : Ihelper1
	{
		public helper1()
		{

		}

		public string GetName()
		{
			return "Kirill";
		}

		public int AddNumbers(int a, int b)
		{
			return a + b;
		}



	}
}
