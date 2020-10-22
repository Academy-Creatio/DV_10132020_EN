define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
		attributes: {
			"MyOwnAttribute": {
				dependencies: [
					{
						columns: ["Email", "Name"],
						methodName: "onEmailOrNameChanged"
					}
				]
			},
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
			init: function() {
				this.callParent(arguments);
			},
			onEntityInitialized: function() {
				this.callParent(arguments);
			},
			onEmailOrNameChanged: function(){
				
				var colChanged = arguments[1];
				if(colChanged == "Email"){
					var email = this.$Email;
					this.showInformationDialog("Email Changed "+email);
				}
				
				if(colChanged == "Name"){
					var name = this.$Name;
					this.showInformationDialog("Name Changed "+name);
				}


			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "Language",
				"values": {
					"layout": {
						"colSpan": 8,
						"rowSpan": 1,
						"column": 12,
						"row": 3
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
