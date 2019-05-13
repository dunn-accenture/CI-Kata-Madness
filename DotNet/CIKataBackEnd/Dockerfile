FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY CIKataBackEnd.WebApi/*.csproj ./BackEndApp/
RUN dotnet restore ./BackEndApp/CIKataBackEnd.WebApi.csproj

# copy everything else and build app
COPY CIKataBackEnd.WebApi/. ./BackEndApp/
WORKDIR /app/BackEndApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/BackEndApp/out ./
ENTRYPOINT ["dotnet", "CIKataBackEnd.WebApi.dll"]
