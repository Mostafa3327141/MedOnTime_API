#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MedOnTime_API/MedOnTime_API.csproj", "MedOnTime_API/"]
COPY ["MedOnTime.Core/MedOnTime.Core.csproj", "MedOnTime.Core/"]
RUN dotnet restore "MedOnTime_API/MedOnTime_API.csproj"
COPY . .
WORKDIR "/src/MedOnTime_API"
RUN dotnet build "MedOnTime_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedOnTime_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedOnTime_API.dll"]