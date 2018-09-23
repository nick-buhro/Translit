ECHO OFF
%USERPROFILE%\.nuget\packages\opencover\4.6.519\tools\OpenCover.Console.exe -register:user "-filter:+[NickBuhro.Translit]* -[*Tests]*" "-target:%USERPROFILE%\.nuget\packages\xunit.runner.console\2.4.0\tools\net461\xunit.console.exe" "-targetargs:.\NickBuhro.Translit.Tests\bin\Debug\net461\NickBuhro.Translit.Tests.dll -noshadow"
%USERPROFILE%\.nuget\packages\ReportGenerator\3.1.2\tools\ReportGenerator.exe "-reports:results.xml" "-reporttypes:MHtml" "-targetdir:.\"
IF DEFINED COVERALLS_REPO_TOKEN (%USERPROFILE%\.nuget\packages\coveralls.io\1.4.2\tools\coveralls.net.exe --opencover results.xml --full-sources)
