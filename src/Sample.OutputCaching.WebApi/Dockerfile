#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Sample.OutputCaching/Sample.OutputCaching.csproj", "Sample.OutputCaching/"]
RUN dotnet restore "Sample.OutputCaching/Sample.OutputCaching.csproj"
COPY . .
WORKDIR "/src/Sample.OutputCaching"
RUN dotnet build "Sample.OutputCaching.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.OutputCaching.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.OutputCaching.dll"]