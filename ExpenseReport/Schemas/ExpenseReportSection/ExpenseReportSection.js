define("ExpenseReportSection", ["ServiceHelper"], function(ServiceHelper) {
	return {
		entitySchemaName: "ExpenseReport",
		attributes:{
			"Description":{
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: "VatId",
				dependencies: [
					{
						columns: ["Description"],
						methodName: "onInitialized"
					}
				]
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			
			//https://academy.creatio.com/documents/technic-sdk/7-16/how-add-button-section
			{
                "operation": "insert",
				//"parentName": "ActionButtonsContainer",
				"parentName": "CombinedModeActionButtonsCardLeftContainer",
                "propertyName": "items",
                "name": "MyButton",
                "values": {
                    itemType: Terrasoft.ViewItemType.BUTTON,
                    caption: "My Section Button",
					click: { bindTo: "getDescription" },
					enabled: {bindTo: "isEnabled"},
                    "layout": {
                        "column": 1,
                        "row": 6,
                        "colSpan": 1
                    }
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {


			isEnabled: function(){

				if(!this.$ActiveRow){
					return !false;
				}
				return !true;
			},

			onMyButtonClick: function(){
				this.getDescription(this.$ActiveRow);

				var serviceData = {
					vatId: this.$Description
				};
					ServiceHelper.callService("VIES", "Validate",
					function(response) {
						var result = response.GetContactIdByNameResult;
						this.showInformationDialog(result);
					}, serviceData, this);
			
				
				debugger;
			},
			
			getDescription: function(){
				// Creation of query instance with "Contact" root schema. 
				var esq = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "ExpenseReport"
				});
				esq.addColumn("Name", "Name");

				// Creation filter by ParentId (ExpenseReport)
				var parentId = this.$ActiveRow;
				var esqFirstFilter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL, "Id", parentId);

				// Adding created filters to collection. 
				esq.filters.add("esqFirstFilter", esqFirstFilter);

				var description = "";
				var scope = this;
				// This collection will include objects, i.e. query results, filtered by two filters.
				esq.getEntityCollection(function (result) {
					if (result.success) {
						result.collection.each(function (item) {
							description = item.$Name;



							var serviceData = {
								vatId: description
							};
								ServiceHelper.callService("VIES", "Validate",
								function(response) {
									var result = response.GetContactIdByNameResult;
									this.showInformationDialog(result);
								}, serviceData, this);






						});
					}
				}, this);

			},
		}
	};
});
