
using AutoMapper;
using LibraryManagementSystem.Application.Books.Commands.AddBook;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Books.Dtos;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();


        CreateMap<AddBookCommand, Book>()
            .ForMember(b => b.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
            .ForMember(b => b.GenreID, opt => opt.MapFrom(src => src.GenreID));


    }
}
