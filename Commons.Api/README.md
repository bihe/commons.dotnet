# nuget.org feed

Set api-key for use with ```dotnet nuget push```

```
nuget setapikey <api-key> -source nuget.org
```

Push to nuget.org

```
dotnet nuget push .\nupkgs\Binggl.Commons.Api.*.nupkg -s https://api.nuget.org/v3/index.json
```

# VSTS nuget feed

https://stackoverflow.com/questions/48068329/push-a-nuget-package-to-vsts-with-net-cli

Download the nuget+Credential-Manager from VSTS.

```
nuget sources Add -Name "mysource" -Source "https://XXX.pkgs.visualstudio.com/_packaging/YYY/nuget/v3/index.json" -username name -password PAT
nuget setapikey mykey -source mysource
```

Push the package:

```
dotnet nuget push .\nupkgs\Commons.Api.*.nupkg --source Binggl.Packages --api-key mykey
```
