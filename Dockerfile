FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

RUN dotnet --version

COPY ./ ./
RUN dotnet restore ToutBox.Challenge.sln

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 5000 5001
COPY --from=build-env /app/out .
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENTRYPOINT ["dotnet", "ToutBox.Challenge.API.dll"]
