using System.Collections.Generic;
using Terrasoft.Core;
using Terrasoft.Core.Factories;
using TC = Terrasoft.Configuration;

namespace DV_10132020_EN_INTERFACES
{
	[DefaultBinding(typeof(IMsgChannelUtilities))]
	public class MsgChannelUtilities : IMsgChannelUtilities
	{
		public void PostMessage(UserConnection userConnection, string senderName, string messageText)
		{
			TC.MsgChannelUtilities.PostMessage(userConnection, senderName, messageText);
		}

		public void PostMessageToAll(string senderName, string messageText)
		{
			TC.MsgChannelUtilities.PostMessageToAll(senderName, messageText);
		}
	}

	
	[DefaultBinding(typeof(IFeatureUtilities))]
	public class FeatureUtilities : IFeatureUtilities
	{
		public int GetFeatureState(UserConnection source, string code)
		{
			return TC.FeatureUtilities.GetFeatureState(source, code);
		}
		public bool GetIsFeatureEnabledForAnyUser(UserConnection source, string code)
		{
			return TC.FeatureUtilities.GetIsFeatureEnabledForAnyUser(source, code);
		}
		public Dictionary<string, int> GetFeatureStates(UserConnection source)
		{
			return TC.FeatureUtilities.GetFeatureStates(source);
		}
		public List<TC.FeatureInfo> GetFeaturesInfo(UserConnection userConnection)
		{
			return TC.FeatureUtilities.GetFeaturesInfo(userConnection);
		}
		public void SetFeatureState(UserConnection source, string code, int state, bool forAllUsers = false)
		{
			TC.FeatureUtilities.SetFeatureState(source, code, state, forAllUsers);
		}
		public void SafeSetFeatureState(UserConnection source, string code, int state, bool forAllUsers = false)
		{
			TC.FeatureUtilities.SafeSetFeatureState(source, code, state, forAllUsers);
		}
		public bool GetIsFeatureEnabled(UserConnection userConnection, string code)
		{
			return TC.FeatureUtilities.GetIsFeatureEnabled(userConnection, code);
		}
		public void CreateFeature(UserConnection source, string code, string name, string description)
		{
			TC.FeatureUtilities.CreateFeature(source, code, name, description);
		}
	}
}