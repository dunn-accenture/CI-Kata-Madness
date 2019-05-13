FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app
COPY *.sln .
COPY CIKataFrontEnd.React/*.csproj ./FrontEndApp/
RUN dotnet restore ./FrontEndApp/CIKataFrontEnd.React.csproj
COPY CIKataFrontEnd.React/. ./FrontEndApp/

#publish everything
WORKDIR /app/FrontEndApp
RUN dotnet publish -c Release -o out

#start the app
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/FrontEndApp/out ./
ENTRYPOINT ["dotnet", "CIKataFrontEnd.React.dll"]
