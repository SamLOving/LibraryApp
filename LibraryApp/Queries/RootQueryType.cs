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
                .Name("Books")
                .Field<BooksResolver>(r => r.GetBooksByIdentifiersAsync(default, default, default))
                .Argument("ids", a => a.Type<NonNullType<ListType<StringType>>>())
                .Type<NonNullType<ListType<NonNullType<BookType>>>>();
        }
    }
}
