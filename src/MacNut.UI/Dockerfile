#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MacNut.UI/MacNut.UI.csproj", "MacNut.UI/"]
COPY ["MacNut.Infrastructure/MacNut.Infrastructure.csproj", "MacNut.Infrastructure/"]
COPY ["MacNut.Domain/MacNut.Domain.csproj", "MacNut.Domain/"]
RUN dotnet restore "MacNut.UI/MacNut.UI.csproj"
COPY . .
WORKDIR "/src/MacNut.UI"
RUN dotnet build "MacNut.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MacNut.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MacNut.UI.dll"]