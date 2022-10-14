# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
#COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
#WORKDIR /app
RUN dotnet publish -c release -o out
#--no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
RUN mkdir -p Documents
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "BadmintonApi.dll"]