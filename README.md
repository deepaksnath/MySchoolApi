**TEST COVERAGE REPORT GENERATE COMMANDS**
dotnet test --collect:"XPlat Code Coverage" --settings .runsettings
reportgenerator -reports:"./**/**/**/*cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
