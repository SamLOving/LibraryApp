using HotChocolate.Types;
using LibraryApp.Models;
using LibraryApp.Resolvers;
using LibraryApp.Types;

namespace LibraryApp.Queries
{
    public class RootQueryType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor
                .Name("Books")
                .Field<BooksResolver>(r => r.GetBooksAsync(default, default, default, default))
                .Argument("ids", a => a.Type<NonNullType<ListType<StringType>>>())
                .Argument("genres", a => a.Type<NonNullType<ListType<EnumType<Genre>>>>())
                .Type<NonNullType<ListType<NonNullType<BookType>>>>();

            descriptor
                .Field<BooksResolver>(r => r.GetDefaultBookAsync(default))
                .Argument("author", a => a.Type<NonNullType<StringType>>())
                .Type<NonNullType<BookType>>();
        }
    }
}
