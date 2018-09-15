# clean
Remove-Item -path ./nupkgs/*
dotnet pack --include-source --include-symbols -c Release --output ../nupkgs src/Commons.Api.csproj
