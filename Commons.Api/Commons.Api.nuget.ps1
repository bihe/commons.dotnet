# clean
Remove-Item -path ./nupkgs/*
dotnet pack /p:PackageVersion=1.0.1 --include-source --include-symbols -c Release --output ../nupkgs src/Commons.Api.csproj