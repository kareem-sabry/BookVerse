using AutoMapper;
using BookVerse.Application.Dtos.Author;
using BookVerse.Application.Dtos.Book;
using BookVerse.Application.Dtos.Cart;
using BookVerse.Application.Dtos.Category;
using BookVerse.Application.Dtos.Order;
using BookVerse.Application.Dtos.User;
using BookVerse.Core.Entities;

namespace BookVerse.Infrastructure.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ConfigureBookMappings();
        ConfigureAuthorMappings();
        ConfigureCategoryMappings();
        ConfigureUserMappings();
        ConfigureCartMappings();
        ConfigureOrderMappings();
    }

    private void ConfigureBookMappings()
    {
        // Book -> BookReadDto (includes related data)
        CreateMap<Book, BookReadDto>()
            .ForMember(dest => dest.Authors,
                opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author)))
            .ForMember(dest => dest.Categories,
                opt => opt.MapFrom(src => src.BookCategories.Select(bc => bc.Category)));

        // Book -> BookBriefDto (minimal data)
        CreateMap<Book, BookBriefDto>();

        // BookCreateDto -> Book
        CreateMap<BookCreateDto, Book>()
            .ForMember(dest => dest.BookAuthors, opt => opt.Ignore())
            .ForMember(dest => dest.BookCategories, opt => opt.Ignore());

        // BookUpdateDto -> Book
        CreateMap<BookUpdateDto, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.BookAuthors, opt => opt.Ignore())
            .ForMember(dest => dest.BookCategories, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAtUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
    }

    private void ConfigureAuthorMappings()
    {
        // Author -> AuthorBriefDto (minimal data)
        CreateMap<Author, AuthorBriefDto>();

        // Author -> AuthorListDto (for list views)
        CreateMap<Author, AuthorListDto>();

        // Author -> AuthorReadDto (includes books)
        CreateMap<Author, AuthorReadDto>()
            .ForMember(dest => dest.Books,
                opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Book)));

        // AuthorCreateDto -> Author
        CreateMap<AuthorCreateDto, Author>()
            .ForMember(dest => dest.BookAuthors, opt => opt.Ignore());

        // AuthorUpdateDto -> Author
        CreateMap<AuthorUpdateDto, Author>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.BookAuthors, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAtUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
    }

    private void ConfigureCategoryMappings()
    {
        // Category -> CategoryBriefDto (minimal data)
        CreateMap<Category, CategoryBriefDto>();

        // Category -> CategoryListDto (for list views)
        CreateMap<Category, CategoryListDto>();

        // Category -> CategoryReadDto (includes books)
        CreateMap<Category, CategoryReadDto>()
            .ForMember(dest => dest.Books,
                opt => opt.MapFrom(src => src.BookCategories.Select(bc => bc.Book)));

        // CategoryCreateDto -> Category
        CreateMap<CategoryCreateDto, Category>()
            .ForMember(dest => dest.BookCategories, opt => opt.Ignore());

        // CategoryUpdateDto -> Category
        CreateMap<CategoryUpdateDto, Category>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.BookCategories, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAtUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
    }

    private void ConfigureUserMappings()
    {
        // User -> UserProfileDto
        CreateMap<User, UserProfileDto>();
    }

    private void ConfigureCartMappings()
    {
        CreateMap<Cart, CartDto>();

        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceAtAdd));
    }

    private void ConfigureOrderMappings()
    {
        CreateMap<Order, OrderReadDto>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

        CreateMap<Order, OrderListDto>()
            .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.OrderItems.Count));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title));
    }
}