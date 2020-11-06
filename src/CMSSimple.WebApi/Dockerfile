#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CMSSimple.WebApi/CMSSimple.WebApi.csproj", "CMSSimple.WebApi/"]
COPY ["CMSSimple.IoC.Config/CMSSimple.IoC.Config.csproj", "CMSSimple.IoC.Config/"]
COPY ["CMSSimple.StorageServices/CMSSimple.StorageServices.csproj", "CMSSimple.StorageServices/"]
COPY ["CMSSimple.BusinessLogic/CMSSimple.BusinessLogic.csproj", "CMSSimple.BusinessLogic/"]
RUN dotnet restore "CMSSimple.WebApi/CMSSimple.WebApi.csproj"
COPY . .
WORKDIR "/src/CMSSimple.WebApi"
RUN dotnet build "CMSSimple.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMSSimple.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMSSimple.WebApi.dll"]
