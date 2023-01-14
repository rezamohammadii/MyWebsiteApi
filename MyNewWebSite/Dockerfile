#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyNewWebSite/MyNewWebSite.csproj", "MyNewWebSite/"]
RUN dotnet restore "MyNewWebSite/MyNewWebSite.csproj"
COPY . .
WORKDIR "/src/MyNewWebSite"
RUN dotnet build "MyNewWebSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyNewWebSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyNewWebSite.dll"]