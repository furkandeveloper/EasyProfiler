#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["samples/EasyProfiler.Web/EasyProfiler.Web.csproj", "samples/EasyProfiler.Web/"]
RUN dotnet restore "samples/EasyProfiler.Web/EasyProfiler.Web.csproj"
COPY . .
WORKDIR "/src/samples/EasyProfiler.Web"
RUN dotnet build "EasyProfiler.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyProfiler.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet EasyProfiler.Web.dll