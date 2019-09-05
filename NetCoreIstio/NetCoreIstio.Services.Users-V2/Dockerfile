FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["NetCoreIstio.Services.Users-V2/NetCoreIstio.Services.Users-V2.csproj", "NetCoreIstio.Services.Users-V2/"]
RUN dotnet restore "NetCoreIstio.Services.Users-V2/NetCoreIstio.Services.Users-V2.csproj"
COPY . .
WORKDIR "/src/NetCoreIstio.Services.Users-V2"
RUN dotnet build "NetCoreIstio.Services.Users-V2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetCoreIstio.Services.Users-V2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreIstio.Services.Users-V2.dll"]




# docker build -t rjgadag/netcore-istio-users-v2:v2 -f E:\2019\Istio\NetCoreIstio\NetCoreIstio.Services.Users-V2\Dockerfile .
# docker tag rjgadag/netcore-istio-users-v2:v2 rjgadag/netcore-istio-users-v2:v2
# docker push rjgadag/netcore-istio-users-v2