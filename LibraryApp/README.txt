Start up application: dotnet run --project LibraryApp/LibraryApp.csproj -c relase

The application is listening at: 
https://localhost:5001
https://localhost:5000

There is a log generated in c:/temp folder.

Schemas:

Get Books:
{
  books(ids: ["ID-0", "ID-2"], genres:[MISTERY, COMEDY, HORROR, ROMANCE]){
    author,
    title
  }
}

Get Books By Identifiers:
{
	booksByIdentifiers(ids: ["ID-0", "ID-1", "ID-2", "ID-3"]) {
    id
    author
    title
    genre
  }
}


