FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["NetCoreIstio.Services.Users/NetCoreIstio.Services.Users.csproj", "NetCoreIstio.Services.Users/"]
RUN dotnet restore "NetCoreIstio.Services.Users/NetCoreIstio.Services.Users.csproj"
COPY . .
WORKDIR "/src/NetCoreIstio.Services.Users"
RUN dotnet build "NetCoreIstio.Services.Users.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetCoreIstio.Services.Users.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreIstio.Services.Users.dll"]




# docker build -t rjgadag/netcore-istio-users:v1 -f E:\2019\Istio\NetCoreIstio\NetCoreIstio.Services.Users\Dockerfile .
# docker tag rjgadag/netcore-istio-users:v1 rjgadag/netcore-istio-users:v1
# docker push rjgadag/netcore-istio-users