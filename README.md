<p align="center">
    <a href="https://www.creatio.com/">
            <img src="https://github.com/kirillkrylov/ImagesAndPages/wiki/Img/accelerateBannerBlue.png">
    </a>
</p>

# Development on Creation Platform (DV_10132020_EN) with _[Kirill Krylov][aboutKirill]_
General description of topics covered can be found [here][wikiTraining]
If you have any questions or issues please raise them [here][issues], or email me directly.

## Visual Studio - Item Templates
Please copy content of DV_10132020_ITEM_TEMPLATES folder to
%USERPROFILE%\Documents\Visual Studio 2019\Templates\ItemTemplates\Visual C#


## Academy Articles
- [CRUD Operations][crud]
- [Entity Event Layer][nEEL]  
- [Configuration Web Service][nConfWebService]  
- [Working with DataBase][nWWDB]  
- [Project Package][nProjectPackage]
- [Postman Collection][postManCollection]
- [Data Service][DataService]
- [oData Version 3][oData3]
- [oData Version 4][oData4]

## Other projects we will make use of
- [Working with Data][pWorkingWithData] - Day 3
- [Foreign Exchange][pForeignExchange]
- [Expense Report Start Package][pExpenseReportStart]

## FEEDBACK
Thank you for having taken development training with me. In order to make this class better, please offer your feedback 
through **[feedback form][FeedBackForm]**.It is very important for me to know where and how I can improve.

## Video recordings (Files will be deleted on 12 Nov, 2020)
| Day      | Play           | Download          | Chat        |
|:--------:|:--------------:|:-----------------:|:------------|
| Day 1    | [Play][Day1P]  |[Download][Day1D]  |[Chat][Day1C]|
| Day 2    | [Play][Day2P]  |[Download][Day2D]  |[Chat][Day2C]|
| Day 3    | [Play][Day3P]  |[Download][Day3D]  |[Chat][Day3C]|
| Day 4    | [Play][Day4P]  |[Download][Day4D]  |  |
| Day 5    | [Play][Day5P]  |[Download][Day5D]  |  |
<!--
| Day 6    | [Play][Day6P]  |[Download][Day6D]  |[Chat][Day6C]|
| Day 7    | [Play][Day7P]  |[Download][Day7D]  |[Chat][Day7C]|
| Day 8    | [Play][Day8P]  |[Download][Day8D]  |[Chat][Day8C]|

-->

## Building joins with ESQ
```cs
//Left join 
esq.addColumn(">Account.Name") or esq.addColumn("Account.Name")
 
//Right join
esq.addColumn("<Account.Name")
 
//Inner join
esq.addColumn("=Account.Name")
 
//Cross join
esq.addColumn("<>Account.Name")
```

## SQL to convert UserTask to Process Element (do data binding after)
```SQL
insert into SysProcessUserTask(SysUserTaskSchemaUId, Caption)
select s.UId, s.Caption from SysSchema s
where s.Name = 'ForeignExchange'
```


## Individual Assignments
<details>
<summary>Day 1 - Environment Set up</summary>

- [Install][wikiInstallCreatio] local development environment
- Convert Creatio to development in [File System Mode][wikiFileSystemMode]
- Configure your own [logger][wikiLogging]
<!-- - Pull [Expense Report Start][pExpenseReportStart] package and install it -->

</details>

<details>
<summary>Day 2 - Clio</summary>

- Create and interface and implement a class inside Terrasoft.Configuration that will allow Clio project to send WebSocket Messages (MsgChannelUtilities). You can observer messages on **ViewModule.aspx.ashx** page
<!-- - Pull [Expense Report Start][pExpenseReportStart] package and install it -->

</details>

<details>vat
<summary>Day 3 and 4 - Working with Data</summary>

- Add new activity type, and change the overlapping activity code to only detect your own activity type
- Try to build a class that would check VAT number aginst the oficial VIES database (https://ec.europa.eu/taxation_customs/vies/technicalInformation.html)
Implement an entity event listener for the Account  entity to validate VAT. Add VAT field to account.


</details>


<!-- Named Links-->
[pForeignExchange]: https://github.com/Academy-Creatio/ForeignExchange
[pExpenseReportStart]:https://github.com/Academy-Creatio/ExpenseReportStart
[pWorkingWithData]: https://github.com/Academy-Creatio/WorkshopWorkingWithData_2020-08-11
[FeedBackForm]:https://forms.office.com/Pages/ResponsePage.aspx?id=-6Jce0OmhUOLOTaTQnDHFmSQPwRGgxpCmR4ucwVD2MxUOEE4UzZWRUpHQVlKQjFMVzRES1ZaNlRKQyQlQCN0PWcu
[aFeatureToggle]: https://academy.creatio.com/documents/technic-sdk/7-16/feature-toggle-mechanism-enabling-and-disabling-functions


[nConfWebService]: https://academy.creatio.com/documents/technic-sdk/7-16/creating-configuration-service
[nEEL]: https://academy.creatio.com/documents/technic-sdk/7-16/entity-event-layer
[nWWDB]: https://academy.creatio.com/documents/technic-sdk/7-16/working-database
[nProjectPackage]:https://academy.creatio.com/documents/technic-sdk/7-16/developing-source-code-file-content-project-package
[nCLio]: https://github.com/Advance-Technologies-Foundation/clio
[GitHubProfile]: https://github.com/kirillkrylov
[email]: mailto:k.krylov@creatio.com
[oData3]: https://academy.creatio.com/documents/technic-sdk/7-16/creatio-integration-odata-3-protocol
[oData4]: https://academy.creatio.com/documents/technic-sdk/7-16/creatio-integration-odata-4-protocol
[DataService]: https://academy.creatio.com/documents/technic-sdk/7-16/dataservice
[postManCollection]: https://documenter.getpostman.com/view/10204500/SztHX5Qb?version=latest
[crud]: https://academy.creatio.com/documents/technic-sdk/7-16/crud-operations
[aboutKirill]:https://github.com/Academy-Creatio/TrainingProgramm/wiki/Kirill-Krylov,-CPA
[wikiTraining]:https://github.com/Academy-Creatio/TrainingProgramm/wiki
[issues]:https://github.com/Academy-Creatio/DV_10132020_EN/issues


[wikiLogging]:https://github.com/Academy-Creatio/TrainingProgramm/wiki/Custom-Logging-with-NLog
[wikiFileSystemMode]:https://github.com/Academy-Creatio/TrainingProgramm/wiki/Enable-development-in-FileSystem-Mode
[wikiInstallCreatio]: https://github.com/Academy-Creatio/TrainingProgramm/wiki/How-To-Install-Creatio


<!-- Video Links-->

[Day1P]: https://us02web.zoom.us/rec/play/TyO4naRdYlFH0HIWJeb6hhdsj0TydJ8eeGvuAi1A0qwQJ60lPFg_hJq32ZATNWUJ2brnqMlf8YVYHbCn.CVf5-Y9DkEkF4chX
[Day1D]: https://us02web.zoom.us/rec/download/TyO4naRdYlFH0HIWJeb6hhdsj0TydJ8eeGvuAi1A0qwQJ60lPFg_hJq32ZATNWUJ2brnqMlf8YVYHbCn.CVf5-Y9DkEkF4chX
[Day1C]: https://us02web.zoom.us/rec/download/yyQMtoH7fciTaIhwP4j4x1r67GtpHwBmIi--kmIwiQgKMQLSQJOzu2DDygQCgueB4LYt9-C5UihMzITx.R4G9nVTCcibDyeGZ


[Day2P]: https://us02web.zoom.us/rec/play/IoxPuLEXWbbZ5VolndAPelobEYscN1h8YzNFLyzrsYc0cf8akgEJJrp_enZ6b_vS02BUsJR2kFy1oFWF.qe8za6PDrQ5ByEZW
[Day2D]: https://us02web.zoom.us/rec/download/IoxPuLEXWbbZ5VolndAPelobEYscN1h8YzNFLyzrsYc0cf8akgEJJrp_enZ6b_vS02BUsJR2kFy1oFWF.qe8za6PDrQ5ByEZW
[Day2C]: https://us02web.zoom.us/rec/download/8JgMY8P_sUmq97PNYjhN1M37l2o3iO_bP8baZdIf6u2yfg_uBrw220sN3Ud3ATTvR54azDU6CsFl3Kgd.-IG6rd0IECvhx3bl

[Day3P]: https://us02web.zoom.us/rec/play/SFN7MSG0DdMCO7IDT8eN3Q0usvv2-A4vdfxbVAYM_zVd8CzC_puHuBHavofaU1TpZK3eVM6eFHo-S87F._qUqOTG26TD2ZK0h
[Day3D]: https://us02web.zoom.us/rec/download/SFN7MSG0DdMCO7IDT8eN3Q0usvv2-A4vdfxbVAYM_zVd8CzC_puHuBHavofaU1TpZK3eVM6eFHo-S87F._qUqOTG26TD2ZK0h
[Day3C]: https://us02web.zoom.us/rec/download/M_uCNpfY7inT-y9OpeBSwQodIGSxCKT1vtNcv2AviY4lEcpgRqF1kqZyFCASrNt80FQ3sX__PZ_-6YRQ.gLve25_iSiq3fvW4

[Day4P]: https://us02web.zoom.us/rec/play/paUT4fnxhmxe3eKtAjsJ8mIcQ4HD1ebbhp4cEe2MeWQ3l0Tm0F7llu2elEwazfoSlRGJ_0MH6_m-oNzf.3tIINzkFX9JAr18B
[Day4D]: https://us02web.zoom.us/rec/download/paUT4fnxhmxe3eKtAjsJ8mIcQ4HD1ebbhp4cEe2MeWQ3l0Tm0F7llu2elEwazfoSlRGJ_0MH6_m-oNzf.3tIINzkFX9JAr18B


[Day5P]: https://us02web.zoom.us/rec/play/SJbvurRuCp8d6OgJiTz_-7lUIMSVEtVdp86E66ME1kOT7sB7RvcSDIhmGrubsRqQf9SLgzWx5OILjRl2.Ix2uF1C-ztsUOfnd
[Day5D]: https://us02web.zoom.us/rec/download/SJbvurRuCp8d6OgJiTz_-7lUIMSVEtVdp86E66ME1kOT7sB7RvcSDIhmGrubsRqQf9SLgzWx5OILjRl2.Ix2uF1C-ztsUOfnd
[Day5C]: 
<!--

[Day6P]: 
[Day6D]: 
[Day6C]: 

[Day7P]: 
[Day7D]: 
[Day7C]: 

[Day8P]: 
[Day8D]: 
[Day8C]: 
-->