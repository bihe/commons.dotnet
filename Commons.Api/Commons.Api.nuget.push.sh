#!/bin/sh
dotnet nuget push .\nupkgs\Binggl.Commons.Api.*.nupkg -s https://api.nuget.org/v3/index.json
