FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["askon-test-api/askon-test-api.csproj", "askon-test-api/"]
RUN dotnet restore "askon-test-api/askon-test-api.csproj"
COPY . .
WORKDIR "/src/askon-test-api"
RUN dotnet build "askon-test-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "askon-test-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "askon-test-api.dll"]
