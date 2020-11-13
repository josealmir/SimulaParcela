FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SimulaParcela.Api/SimulaParcela.Api.csproj", "SimulaParcela.Api/"]
COPY ["SimulaParcela.Repositorio/SimulaParcela.Repositorio.csproj", "SimulaParcela.Repositorio/"]
COPY ["SimulaParcela.Domain/SimulaParcela.Domain.csproj", "SimulaParcela.Domain/"]
RUN dotnet restore "SimulaParcela.Api/SimulaParcela.Api.csproj"
COPY . .
WORKDIR "/src/SimulaParcela.Api"
RUN dotnet build "SimulaParcela.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SimulaParcela.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SimulaParcela.Api.dll"]