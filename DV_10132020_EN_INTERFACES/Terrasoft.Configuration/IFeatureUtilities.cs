using System;
using System.Collections.Generic;
using System.Text;
using Terrasoft.Core;

namespace DV_10132020_EN_INTERFACES
{
	public interface IFeatureUtilities
	{
		void CreateFeature(UserConnection source, string code, string name, string description);
		//List<FeatureInfo> GetFeaturesInfo(UserConnection userConnection);
		int GetFeatureState(UserConnection source, string code);
		Dictionary<string, int> GetFeatureStates(UserConnection source);
		bool GetIsFeatureEnabled(UserConnection userConnection, string code);
		bool GetIsFeatureEnabledForAnyUser(UserConnection source, string code);
		void SafeSetFeatureState(UserConnection source, string code, int state, bool forAllUsers = false);
		void SetFeatureState(UserConnection source, string code, int state, bool forAllUsers = false);
	}
}
