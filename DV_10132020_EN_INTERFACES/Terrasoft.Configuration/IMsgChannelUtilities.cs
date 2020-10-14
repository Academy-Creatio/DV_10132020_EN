using Terrasoft.Core;

namespace DV_10132020_EN_INTERFACES
{
	public interface IMsgChannelUtilities
	{
		/// <summary>
		/// Send web socket message to a user identified by UserConnection
		/// </summary>
		/// <param name="userConnection"></param>
		/// <param name="senderName">usually class name or method name</param>
		/// <param name="messageText">usually json serialized string</param>
		void PostMessage(UserConnection userConnection, string senderName, string messageText);


		/// <summary>
		/// Send web socket message to all users
		/// </summary>
		/// <param name="senderName">usually class name or method name</param>
		/// <param name="messageText">usually json serialized string</param>
		void PostMessageToAll(string senderName, string messageText);
	}
}
