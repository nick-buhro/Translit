%USERPROFILE%\.nuget\packages\opencover\4.6.519\tools\OpenCover.Console.exe -register:user "-filter:+[NickBuhro.Translit]* -[*Tests]*" "-target:%USERPROFILE%\.nuget\packages\xunit.runner.console\2.2.0\tools\xunit.console.exe" "-targetargs:.\NickBuhro.Translit.Tests\bin\Debug\net46\NickBuhro.Translit.Tests.dll -noshadow"
%USERPROFILE%\.nuget\packages\ReportGenerator\2.5.8\tools\ReportGenerator.exe "-reports:results.xml" "-targetdir:.\Coverage"

echo off
:: "-filter:+[NickBuhro.Translit]* -[*Tests]*"
REM .\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -register:user "-filter:+[Bom]* -[*Test]*" "-target:.\packages\NUnit.Runners.2.6.4\tools\nunit-console-x86.exe" "-targetargs:/noshadow .\BomTest\bin\Debug\BomTest.dll"
REM .\packages\ReportGenerator.2.1.8.0\tools\ReportGenerator.exe "-reports:results.xml" "-targetdir:.\coverage"

pause