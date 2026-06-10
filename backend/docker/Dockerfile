FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY BookVerseApi.sln ./

COPY src/BookVerse.Core/*.csproj src/BookVerse.Core/
COPY src/BookVerse.Application/*.csproj src/BookVerse.Application/
COPY src/BookVerse.Infrastructure/*.csproj src/BookVerse.Infrastructure/
COPY src/BookVerse.Api/*.csproj src/BookVerse.Api/

COPY tests/BookVerse.Tests/*.csproj tests/BookVerse.Tests/

RUN dotnet restore BookVerseApi.sln

COPY . .

WORKDIR /src/src/BookVerse.Api
RUN dotnet build BookVerse.Api.csproj -c Release -o /app/build --no-restore


FROM build AS publish
RUN dotnet publish BookVerse.Api.csproj -c Release -o /app/publish \
    --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

COPY --from=publish /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "BookVerse.Api.dll"]