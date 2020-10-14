using Common.Logging;
using System;
using System.Threading.Tasks;
using Terrasoft.Common;
using Terrasoft.Core;
using Terrasoft.Core.Configuration;
using Terrasoft.Core.Factories;
using Terrasoft.Web.Common;

namespace DV_10132020_EN_CLIO
{
	public class AppEventListener : IAppEventListener
	{
		private AppEventContext _appEventContext;
		ILog _logger = LogManager.GetLogger("GuidedLearningLogger");
		#region Constructors: Public
		public AppEventListener()
		{

		}
		public AppEventListener(UserConnection UserConnection)
		{
			this.UserConnection = UserConnection;
		}
		#endregion

		#region Properties : Private

		private AppConnection _appConnection;
		private AppConnection AppConnection
		{
			get
			{
				if (_appConnection == null)
				{
					_appEventContext.CheckArgumentNull("AppEventContext");
					_appConnection = _appEventContext.Application["AppConnection"] as AppConnection;
				}
				return _appConnection;
			}
			set => _appConnection = value;
		}

		private UserConnection _userConnection;
		private UserConnection UserConnection
		{
			get => _userConnection ?? (_userConnection = AppConnection.SystemUserConnection);
			set => _userConnection = value;
		}
		#endregion

		#region Methods: Public

		
		public void OnAppEnd(AppEventContext context)
		{
			_appEventContext = context;
			_logger.Info($"App ended {UserConnection.CurrentUser.Name}");
		}

		public void OnAppStart(AppEventContext context)
		{
			_appEventContext = context;
			_logger.Info($"OnAppStart {UserConnection.CurrentUser.Name}");
		}

		public void OnSessionEnd(AppEventContext context)
		{
			_appEventContext = context;
			_logger.Info($"OnSessionEnd {UserConnection.CurrentUser.Name}");
		}

		public void OnSessionStart(AppEventContext context)
		{
			_appEventContext = context;
			_logger.Info($"OnSessionStart {UserConnection.CurrentUser.Name}");
		}
		#endregion

	}
}