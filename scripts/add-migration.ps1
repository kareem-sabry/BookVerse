param([string]$name)

dotnet ef migrations add $name `
  --project ./BookVerse.Infrastructure/BookVerse.Infrastructure.csproj `
  --startup-project ./BookVerseApi/BookVerseApi.csproj `
  --output-dir Data/Migrations
