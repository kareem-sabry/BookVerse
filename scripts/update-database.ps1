param([string]$migration = $null)

if ($migration) {
    dotnet ef database update $migration `
      --project ./BookVerse.Infrastructure/BookVerse.Infrastructure.csproj `
      --startup-project ./BookVerseApi/BookVerseApi.csproj
}
else {
    dotnet ef database update `
      --project ./BookVerse.Infrastructure/BookVerse.Infrastructure.csproj `
      --startup-project ./BookVerseApi/BookVerseApi.csproj
}