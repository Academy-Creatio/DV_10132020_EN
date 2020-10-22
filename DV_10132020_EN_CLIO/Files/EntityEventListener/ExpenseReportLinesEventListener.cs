using DV_10132020_EN_INTERFACES;
using System;
using System.Runtime.Remoting.Messaging;
using Terrasoft.Core;
using Terrasoft.Core.DB;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Entities.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DV_10132020_EN_CLIO.Files.EntityEventListener
{
	/// <summary>
	/// Listener for 'EntityName' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "ExpenseReportLines")]
	class ExpenseReportLinesEventListener : BaseEntityEventListener
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
		}
		public override void OnSaved(object sender, EntityAfterEventArgs e)
		{
			base.OnSaved(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
			
			decimal amountHC = entity.GetTypedColumnValue<decimal>("AmountHC");
			decimal amountFC = entity.GetTypedColumnValue<decimal>("AmountFC");
			Guid expenseReportId = entity.GetTypedColumnValue<Guid>("ExpenseReportId");

			Select select = new Select(userConnection)
				.Column(Func.Sum("AmountFC"))
				.From("ExpenseReportLines")
				.Where("ExpenseReportId").IsEqual(Column.Parameter(expenseReportId)) as Select;

			var sumFC = select.ExecuteScalar<decimal>();

			const string table = "ExpenseReport";
			Entity expenseReportEntity = userConnection.EntitySchemaManager.GetInstanceByName(table).CreateEntity(userConnection);
			expenseReportEntity.FetchFromDB(expenseReportId);
			expenseReportEntity.SetColumnValue("Total", sumFC);

			if (expenseReportEntity.Save())
			{
				Result r = new Result
				{
					ParentId = expenseReportId,
					SumHc = sumFC
				};
				string message = JsonConvert.SerializeObject(r);
				var msg = Terrasoft.Core.Factories.ClassFactory.Get<IMsgChannelUtilities>();
				msg.PostMessage(userConnection, "CalculateTotal", message);
			}
		}
		#endregion

		#region Methods : Public : OnInsert
		public override void OnInserting(object sender, EntityBeforeEventArgs e)
		{
			base.OnInserting(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		public override void OnInserted(object sender, EntityAfterEventArgs e)
		{
			base.OnInserted(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#region Methods : Public : OnUpdate
		public override void OnUpdating(object sender, EntityBeforeEventArgs e)
		{
			base.OnUpdating(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		public override void OnUpdated(object sender, EntityAfterEventArgs e)
		{
			base.OnUpdated(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#region Methods : Public : OnDelete
		public override void OnDeleting(object sender, EntityBeforeEventArgs e)
		{
			base.OnDeleting(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		public override void OnDeleted(object sender, EntityAfterEventArgs e)
		{
			base.OnDeleted(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#endregion

		#endregion
	}

	[JsonObject]
	public class Result
	{

		[JsonProperty("ParentId")]
		public Guid ParentId { get; set; }

		[JsonProperty("SumHC")]
		public decimal SumHc { get; set; }

	}

}
