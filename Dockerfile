#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["samples/EasyProfiler.Web.Dotnet6/EasyProfiler.Web.Dotnet6.csproj", "samples/EasyProfiler.Web.Dotnet6/"]
COPY ["src/EasyProfiler.PostgreSQL/EasyProfiler.PostgreSQL.csproj", "src/EasyProfiler.PostgreSQL/"]
COPY ["src/EasyProfiler.EntityFrameworkCore/EasyProfiler.EntityFrameworkCore.csproj", "src/EasyProfiler.EntityFrameworkCore/"]
COPY ["src/EasyProfiler.Core/EasyProfiler.Core.csproj", "src/EasyProfiler.Core/"]
COPY ["src/EasyProfiler.CronJob/EasyProfiler.CronJob.csproj", "src/EasyProfiler.CronJob/"]
RUN dotnet restore "samples/EasyProfiler.Web.Dotnet6/EasyProfiler.Web.Dotnet6.csproj"
COPY . .
WORKDIR "/src/samples/EasyProfiler.Web.Dotnet6"
RUN dotnet build "EasyProfiler.Web.Dotnet6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyProfiler.Web.Dotnet6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyProfiler.Web.Dotnet6.dll"]