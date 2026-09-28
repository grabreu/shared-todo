FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Directory.Build.props Directory.Packages.props ./
COPY src/SharedTodo.Api/SharedTodo.Api.csproj src/SharedTodo.Api/

RUN dotnet restore src/SharedTodo.Api/SharedTodo.Api.csproj

COPY src/ src/

RUN dotnet publish src/SharedTodo.Api/SharedTodo.Api.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["dotnet", "SharedTodo.Api.dll"]
