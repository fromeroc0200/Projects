FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebApiCoreDockers/WebApiCoreDockers.csproj", "WebApiCoreDockers/"]
RUN dotnet restore "WebApiCoreDockers/WebApiCoreDockers.csproj"
COPY . .
WORKDIR "/src/WebApiCoreDockers"
RUN dotnet build "WebApiCoreDockers.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApiCoreDockers.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApiCoreDockers.dll"]