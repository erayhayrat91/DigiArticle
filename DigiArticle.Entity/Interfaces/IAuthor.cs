using DigiArticle.Entity.Entities;
using System.Collections.Generic;

namespace DigiArticle.Entity.Interfaces
{
    public interface IAuthor
    {
        List<Author> GetAuthors();
        Author GetAuthorById(int id);
        Author AddAuthor(Author author);
        string GetAuthorName(int id);
        bool DeleteAuthor(int id);
        Author EditAuthor(Author author);
    }
}
