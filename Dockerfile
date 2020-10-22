FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Stockpoint.csproj", "./"]
RUN dotnet restore "Stockpoint.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Stockpoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stockpoint.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stockpoint.dll"]
