Start up application: dotnet run --project LibraryApp/LibraryApp.csproj -c relase

The application is listening at: 
https://localhost:5001
https://localhost:5000

Schema:
Get Books:
{
  books(ids: ["ID-0", "ID-2"], genres:[MISTERY, COMEDY, HORROR, ROMANCE]){
    author,
    title
  }
}


