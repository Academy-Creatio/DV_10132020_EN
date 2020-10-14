using DV_10132020_EN_INTERFACES;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Terrasoft.Core;
using Terrasoft.Web.Common;

namespace DV_10132020_EN_CLIO
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CreatioWsTemplate : BaseService
	{
		#region Properties
		private SystemUserConnection _systemUserConnection;
		private SystemUserConnection SystemUserConnection
		{
			get
			{
				return _systemUserConnection ?? (_systemUserConnection = (SystemUserConnection)AppConnection.SystemUserConnection);
			}
		}
		#endregion

		#region Methods : REST
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string PostMethodName()
		{
			UserConnection userConnection = UserConnection ?? SystemUserConnection;
			return "Ok";
		}


		/// <summary>
		/// Call this service from [AppPath]/0/rest/CreatioWsTemplate/GetMethodname
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string GetMethodname()
		{
			UserConnection userConnection = UserConnection ?? SystemUserConnection;


			IMsgChannelUtilities msg = Terrasoft.Core.Factories.ClassFactory.Get<IMsgChannelUtilities>();
			msg.PostMessage(userConnection, GetType().FullName, "WebSocket Message with factories");
			var h = new helper1();


			return h.GetName();
		}

		#endregion

		#region Methods : Private

		#endregion
	}
}



