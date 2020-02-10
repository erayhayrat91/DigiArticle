using DigiArticle.Entity;
using DigiArticle.Entity.Entities;
using DigiArticle.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigiArticle.Services
{
    public class AuthorService : IAuthor
    {
        private DigiArticleContext _context;

        public AuthorService()
        {
            if (_context == null)
                _context = new DigiArticleContext();
        }

        public Author AddAuthor(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
            return GetAuthorById(author.Id);
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(author => author.Id == id);
        }

        public string GetAuthorName(int id)
        {
            var _author = _context.Authors.FirstOrDefault(author => author.Id == id);
            return _author != null ? _author.FirstName + " " + _author.LastName : "No Author Found";
        }

        public List<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author EditAuthor(Author author)
        {
            var _entity = _context.Authors.Find(author.Id);
            _entity.FirstName = author.FirstName;
            _entity.LastName = author.LastName;
            _entity.MiddleName = author.MiddleName;
            _entity.BirthDate = author.BirthDate;
            var response = _context.Update(_entity);
            if (response.State == EntityState.Modified)
            {
                _context.SaveChanges();
                return _entity;
            }
            else
                return null;
        }

        public bool DeleteAuthor(int id)
        {
            var response = _context.Remove(_context.Authors.Find(id));
            if (response.State == EntityState.Deleted)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
