#!/bin/sh
dotnet pack --include-source --include-symbols -c Release -o nuget src/Commons.Api.csproj
