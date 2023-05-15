FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FootballStats.Api/FootballStats.Api.csproj", "FootballStats.Api/"]
RUN dotnet restore "FootballStats.Api/FootballStats.Api.csproj"
COPY . .
WORKDIR "/src/FootballStats.Api"
RUN dotnet build "FootballStats.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FootballStats.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FootballStats.Api.dll"]
