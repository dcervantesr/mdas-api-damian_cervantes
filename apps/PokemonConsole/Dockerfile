#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["apps/PokemonConsole/PokemonConsole.csproj", "apps/PokemonConsole/"]
COPY ["src/Pokemon/Pokemon.csproj", "src/Pokemon/"]
RUN dotnet restore "apps/PokemonConsole/PokemonConsole.csproj"
COPY . .
WORKDIR "/src/apps/PokemonConsole"
RUN dotnet build "PokemonConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PokemonConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PokemonConsole.dll"]