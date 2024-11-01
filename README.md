**MY SCHOOL API**
A web api application developed for learning purpose with technologies,
.Net Core 8
Entity Framework 8
SQL Server
Azure AD
Azure Application Insights
Serilog
Docker
Coverlet
Report Generator


**TEST COVERAGE REPORT GENERATE COMMANDS**
dotnet test --collect:"XPlat Code Coverage" --settings .runsettings
reportgenerator -reports:"./**/**/**/*cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
