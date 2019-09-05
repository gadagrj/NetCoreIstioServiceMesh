FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["NetCoreIstio.Web/NetCoreIstio.Web.csproj", "NetCoreIstio.Web/"]
RUN dotnet restore "NetCoreIstio.Web/NetCoreIstio.Web.csproj"
COPY . .
WORKDIR "/src/NetCoreIstio.Web"
RUN dotnet build "NetCoreIstio.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetCoreIstio.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreIstio.Web.dll"]

# docker build -t rjgadag/netcore-istio-web:v1 -f E:\2019\Istio\NetCoreIstio.Web\Dockerfile .
# docker tag rjgadag/netcore-istio-web:v1 rjgadag/netcore-istio-web:v1
# docker push rjgadag/netcore-istio-web