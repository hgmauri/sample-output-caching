FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Sample.OutputCaching.WebApi/Sample.OutputCaching.WebApi.csproj", "src/Sample.OutputCaching.WebApi/"]
RUN dotnet restore "src/Sample.OutputCaching.WebApi/Sample.OutputCaching.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Sample.OutputCaching.WebApi"
RUN dotnet build "Sample.OutputCaching.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.OutputCaching.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.OutputCaching.WebApi.dll"]