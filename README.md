**MY SCHOOL API** <br />
A web api application developed for learning purpose with technologies,<br />
.Net Core 8<br />
Entity Framework 8<br />
SQL Server<br />
Azure AD<br />
Azure Application Insights<br />
Serilog<br />
Docker<br />
Coverlet<br />
Report Generator<br />


**TEST COVERAGE REPORT GENERATE COMMANDS**<br />
dotnet test --collect:"XPlat Code Coverage" --settings .runsettings<br />
reportgenerator -reports:"./**/**/**/*cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html<br />
