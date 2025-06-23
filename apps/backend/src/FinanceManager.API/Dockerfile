FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/FinanceManager.API/FinanceManager.API.csproj", "src/FinanceManager.API/"]
COPY ["src/FinanceManager.Application/FinanceManager.Application.csproj", "src/FinanceManager.Application/"]
COPY ["src/FinanceManager.Infrastructure/FinanceManager.Infrastructure.csproj", "src/FinanceManager.Infrastructure/"]
COPY ["src/FinanceManager.Domain/FinanceManager.Domain.csproj", "src/FinanceManager.Domain/"]
RUN dotnet restore "src/FinanceManager.API/FinanceManager.API.csproj"
COPY . .
WORKDIR "/src/src/FinanceManager.API"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FinanceManager.API.dll"]
