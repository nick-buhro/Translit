ECHO OFF
%USERPROFILE%\.nuget\packages\opencover\4.6.519\tools\OpenCover.Console.exe -register:user "-filter:+[NickBuhro.Translit]* -[*Tests]*" "-target:%USERPROFILE%\.nuget\packages\xunit.runner.console\2.2.0\tools\xunit.console.exe" "-targetargs:.\NickBuhro.Translit.Tests\bin\Debug\net46\NickBuhro.Translit.Tests.dll -noshadow"
%USERPROFILE%\.nuget\packages\ReportGenerator\2.5.8\tools\ReportGenerator.exe "-reports:results.xml" "-reporttypes:MHtml" "-targetdir:.\"
IF DEFINED COVERALLS_REPO_TOKEN (%USERPROFILE%\.nuget\packages\coveralls.io\1.3.4\tools\coveralls.net.exe --opencover results.xml --full-sources)
