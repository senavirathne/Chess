FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app/

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Chess/Server/Chess.Server.csproj ./Chess/Server/
COPY Chess/Client/Chess.Client.csproj ./Chess/Client/
COPY Chess/Shared/Chess.Shared.csproj ./Chess/Shared/

RUN dotnet restore 

# Copy everything else and build
COPY Chess/Server/. ./Chess/Server/
COPY Chess/Client/. ./Chess/Client/
COPY Chess/Shared/. ./Chess/Shared/

WORKDIR /app/Chess/Server/

RUN dotnet publish Chess.Server.csproj -c Release -o out

## Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/Chess/Server/out .
COPY --from=build-env /app/Chess/Server/DB/chessDB.db ./DB/chessDB.db

#ENTRYPOINT ["dotnet", "Chess.Server.dll", "--urls", "http://*:$PORT"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Chess.Server.dll
