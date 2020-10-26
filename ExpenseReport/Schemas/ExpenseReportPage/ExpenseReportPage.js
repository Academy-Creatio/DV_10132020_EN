define("ExpenseReportPage", [], function() {
	return {
		entitySchemaName: "ExpenseReport",
		attributes: {
			"VirtualTotal": {
				dataValueType: this.Terrasoft.DataValueType.FLOAT,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				caption: "Virtual Total",
				"value": 0
			},
		},
		modules: /**SCHEMA_MODULES*/{
			"Indicator1f1d1665-56f5-425a-95a2-9310bea360dc": {
				"moduleId": "Indicator1f1d1665-56f5-425a-95a2-9310bea360dc",
				"moduleName": "CardWidgetModule",
				"config": {
					"parameters": {
						"viewModelConfig": {
							"widgetKey": "Indicator1f1d1665-56f5-425a-95a2-9310bea360dc",
							"recordId": "0aa58783-af5e-4543-9a41-ae68657b7c21",
							"primaryColumnValue": {
								"getValueMethod": "getPrimaryColumnValue"
							}
						}
					}
				}
			}
		}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"Files": {
				"schemaName": "FileDetailV2",
				"entitySchemaName": "ExpenseReportFile",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "ExpenseReport"
				}
			}, 
			"ExpenseReportLines": {
				"schemaName": "ExpenseReportLinesDetail",
				"entitySchemaName": "ExpenseReportLines",
				"filter": {
					"detailColumn": "ExpenseReport",
					"masterColumn": "Id"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		messages: {
			//PublishedOn: ExpenseReportLinesPage (package: ExpenseReport)
			"ExpenseReportLineAmountFcChanged": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			"ExpenseReportLineAmountHcChanged": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {
			init: function(){
				this.callParent(arguments);
				this.subscribeToMessages();
			},
			

			//Runs after data is loaded
			onEntityInitialized: function() {
				this.callParent(arguments);
				//this.calculateTotalAmount();

				if(this.isEditMode()){
					this.set("VirtualTotal", this.$Total);
				}
			},
			calculateTotalAmount: function(){
				// Creation of query instance with "Contact" root schema. 
				var esq = Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "ExpenseReportLines"
				});
				esq.addColumn("AmountHC", "HomeAmount");
				esq.addColumn("AmountFC", "ForeignAmount");
				esq.addColumn("FxRate", "FxRate");

				// Creation filter by ParentId (ExpenseReport)
				var parentId = this.$Id;
				var esqFirstFilter = esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL, "ExpenseReport", parentId);

				// Adding created filters to collection. 
				esq.filters.add("esqFirstFilter", esqFirstFilter);

				var sumHC = 0.0;
				var sumFC = 0.0;
				var scope = this;
				// This collection will include objects, i.e. query results, filtered by two filters.
				esq.getEntityCollection(function (result) {
					if (result.success) {
						result.collection.each(function (item) {
							sumHC += parseFloat(item.$HomeAmount);
							sumFC += parseFloat(item.$ForeignAmount);	
						});
					}
					scope.set("VirtualTotal", sumFC);
				}, this);
			},
			subscribeToMessages: function(){
				
				//Subscription to WebSocket messages
				//Handler == onServerChannelMessageReceived
				this.Terrasoft.ServerChannel.on(this.Terrasoft.EventName.ON_MESSAGE, this.onServerChannelMessageReceived, this);

				this.sandbox.subscribe(
					"ExpenseReportLineAmountFcChanged", 
					function(){this.calculateTotalAmount(arguments);},
					this, 
					["THIS_IS_MY_TAG2"]);
				
				this.sandbox.subscribe(
					"ExpenseReportLineAmountHcChanged", 
					function(){this.calculateTotalAmount();},
					this, 
					["THIS_IS_MY_TAG2"]);
			},
			onServerChannelMessageReceived: function(){

				var message = arguments[1];
				if(message && message.Header && message.Body){
					if(message.Header.Sender == "CalculateTotal"){
						var body = JSON.parse(message.Body);
						this.set("VirtualTotal", body.SumHC);
						//this.showInformationDialog(body.SumHC);
					}
				}
			},
			onMyButtonClick: function(){
                    var recordId = this.$Description;
                    var serviceData = {
                        vatId: recordId
                    };
                    ServiceHelper.callService("C#ClassName", "C#MethodName",
                        function(response) {
                            var result = response.GetContactIdByNameResult;
							
							this.showInformationDialog(result);
                        }, serviceData, this);
                
				
				
				
				var Id = this.$Id;
				var Name = this.$Name;
				this.showInformationDialog("My Page Button Clicked "+Name+" "+Id);
			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Name"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DATE",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "ReportDate",
					"enabled": true
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Contact",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Contact",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Total",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "VirtualTotal",
					"enabled": false
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Status",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Status",
					"enabled": true,
					"contentType": 3
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "Indicator1f1d1665-56f5-425a-95a2-9310bea360dc",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 4,
						"column": 0,
						"row": 5,
						"layoutName": "ProfileContainer",
						"useFixedColumnHeight": true
					},
					"itemType": 4,
					"classes": {
						"wrapClassName": [
							"card-widget-grid-layout-item"
						]
					}
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "FinancialDetailsTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.FinancialDetailsTabCaption"
					},
					"items": [],
					"order": 0
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ExpenseReportLines",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "FinancialDetailsTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "NotesAndFilesTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.NotesAndFilesTabCaption"
					},
					"items": [],
					"order": 1
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Files",
				"values": {
					"itemType": 2
				},
				"parentName": "NotesAndFilesTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "NotesControlGroup",
				"values": {
					"itemType": 15,
					"caption": {
						"bindTo": "Resources.Strings.NotesGroupCaption"
					},
					"items": []
				},
				"parentName": "NotesAndFilesTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Notes",
				"values": {
					"bindTo": "Notes",
					"dataValueType": 1,
					"contentType": 4,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"imageLoaded": {
							"bindTo": "insertImagesToNotes"
						},
						"images": {
							"bindTo": "NotesImagesCollection"
						}
					}
				},
				"parentName": "NotesControlGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "ESNTab",
				"values": {
					"order": 2
				}
			},
/**
 * Button
 */

			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "MyButton",
				"values": {
					itemType: Terrasoft.ViewItemType.BUTTON,
					caption: "My Page Button",
					click: {bindTo: "onMyButtonClick"},
					enabled: true,
					"layout": {
						"column": 1,
						"row": 6,
						"colSpan": 1
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
