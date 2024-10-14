FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

RUN ["apt-get", "update"]
RUN ["apt-get", "install", "-y", "nano"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["EFilm.Api/EFilm.Api.csproj", "EFilm.Api/"]
COPY ["EFilm.Application/EFilm.Application.csproj", "EFilm.Application/"]
COPY ["EFilm.Data/EFilm.Data.csproj", "EFilm.Data/"]
COPY ["EFilm.Data.EF/EFilm.Data.EF.csproj", "EFilm.Data.EF/"]
COPY ["EFilm.Infrastructure/EFilm.Infrastructure.csproj", "EFilm.Infrastructure/"]
#COPY ["nuget.config", "nuget.config"]
RUN dotnet restore "EFilm.Api/EFilm.Api.csproj"

COPY . .
WORKDIR "/src/EFilm.Api"
RUN dotnet build "EFilm.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFilm.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "EFilm.Api.dll"]