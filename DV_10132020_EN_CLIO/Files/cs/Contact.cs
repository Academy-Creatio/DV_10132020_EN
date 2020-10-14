using System;
using Terrasoft.Core;
using Terrasoft.Core.Entities.AsyncOperations;
using Terrasoft.Core.Entities.AsyncOperations.Interfaces;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Entities.Events;
using Terrasoft.Core.Factories;
using Terrasoft.Configuration;
using Terrasoft.Common;

namespace DV_10132020_EN_CLIO.Files.cs
{
	/// <summary>
	/// Listener for 'EntityName' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Contact")]
	class ContactEventListener : BaseEntityEventListener
	{
		#region Enum
		#endregion

		#region Delegates
		#endregion

		#region Constants
		#endregion

		#region Fields

		#region Fileds : Private
		#endregion

		#region Fileds : Protected
		#endregion

		#region Fileds : Internal
		#endregion

		#region Fileds : Protected Internal
		#endregion

		#region Fileds : Public
		#endregion

		#endregion

		#region Properties

		#region Properties : Private
		#endregion

		#region Properties : Protected
		#endregion

		#region Properties : Internal
		#endregion

		#region Properties : Protected Internal
		#endregion

		#region Properties : Public
		#endregion

		#endregion

		#region Events
		#endregion

		#region Methods

		#region Methods : Private

		#endregion

		#region Methods : Public

		#region Methods : Public : OnSave
		public override void OnSaving(object sender, EntityBeforeEventArgs e)
		{
			base.OnSaving(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
			var oldName = entity.GetTypedColumnValue<string>("Name");



			if (oldName.Contains("Kirill"))
			{
				e.IsCanceled = true;
				MsgChannelUtilities.PostMessage(userConnection, this.GetType().FullName, "I am cancelling this, because ....");
			}

			entity.SetColumnValue("Name", $"{oldName} - test listener");
		}
		public override void OnSaved(object sender, EntityAfterEventArgs e)
		{
			base.OnSaved(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
			
		}
		#endregion

	

		#endregion

		#endregion
	}
}
