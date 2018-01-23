FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 808

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Docker.Webhook.Deploy/Docker.Webhook.Deploy.csproj Docker.Webhook.Deploy
RUN dotnet restore
COPY . .
WORKDIR /src/Docker.Webhook.Deploy
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Docker.Webhook.Deploy.dll"]
