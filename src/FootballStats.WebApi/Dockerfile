FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FootballStats.WebApi/FootballStats.WebApi.csproj", "FootballStats.WebApi/"]
RUN dotnet restore "FootballStats.WebApi/FootballStats.WebApi.csproj"
COPY . .
WORKDIR "/src/FootballStats.WebApi"
RUN dotnet build "FootballStats.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FootballStats.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FootballStats.WebApi.dll"]
