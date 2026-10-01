FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Directory.Build.props Directory.Packages.props ./
COPY src/SharedTodo.Api/SharedTodo.Api.csproj src/SharedTodo.Api/

RUN dotnet restore src/SharedTodo.Api/SharedTodo.Api.csproj --runtime linux-x64

COPY src/ src/

RUN dotnet publish src/SharedTodo.Api/SharedTodo.Api.csproj -c Release -o /app --no-restore

RUN dotnet tool install --global dotnet-ef --version 10.0.12
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations bundle \
    --project src/SharedTodo.Api/SharedTodo.Api.csproj \
    --configuration Release \
    --self-contained \
    --runtime linux-x64 \
    --output /app/efbundle

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["dotnet", "SharedTodo.Api.dll"]
