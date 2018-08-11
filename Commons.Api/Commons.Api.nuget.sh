#!/bin/sh
dotnet pack /p:PackageVersion=1.0.0 --include-source --include-symbols -c Release -o nuget src/Commons.Api.csproj