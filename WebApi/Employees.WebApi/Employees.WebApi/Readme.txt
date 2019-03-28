Se ejecutan los siguientes comandos en el web api desde consola de nuget en menu tools de VS

# NuGet Command : Install Web API Cors
Install-Package Microsoft.AspNet.WebApi.Cors 

# NuGet Command : Fix Version Compactability of Cors and Http
Update-Package Microsoft.AspNet.WebApi -reinstall
Install-Package Microsoft.AspNet.WebApi.Core