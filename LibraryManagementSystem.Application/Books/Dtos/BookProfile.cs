
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
            .ForMember(b => b.Author, opt => opt.MapFrom(
            src => new Author
            {
                AuthorID = src.AuthorID,
            }
            ))
            .ForMember(b => b.Genre, opt => opt.MapFrom(
            src => new Genre
            {
                GenreID = src.GenreID,
            }
            ))
            ;
            
    }
}
