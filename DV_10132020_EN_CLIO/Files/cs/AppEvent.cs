using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrasoft.Core;
using Terrasoft.Core.Factories;
using Terrasoft.Web.Common;

namespace DV_10132020_EN_CLIO.Files.cs
{
	[DefaultBinding(typeof(IAppEventListener))]
	class AppEvent : IAppEventListener
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("GuidedLearningLogger");
		UserConnection userConnection;
		#endregion


		#region Constructors: Public
		public AppEvent()
		{

		}
		public AppEvent(UserConnection UserConnection)
		{
			userConnection = UserConnection;
		}
		#endregion

		public void OnAppEnd(AppEventContext context)
		{

			

			_log.Info($"App ended {userConnection.CurrentUser.Name}");
		}

		public void OnAppStart(AppEventContext context)
		{
			_log.Info($"OnAppStart {userConnection.CurrentUser.Name}");
		}

		public void OnSessionEnd(AppEventContext context)
		{
			_log.Info($"OnSessionEnd {userConnection.CurrentUser.Name}");
		}

		public void OnSessionStart(AppEventContext context)
		{
			_log.Info($"OnSessionStart {userConnection.CurrentUser.Name}");
		}
	}
}
