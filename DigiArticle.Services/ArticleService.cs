using DigiArticle.Entity;
using DigiArticle.Entity.Entities;
using DigiArticle.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiArticle.Services
{
    public class ArticleService : IArticle
    {
        private DigiArticleContext _context;

        public ArticleService()
        {
            if (_context == null)
                _context = new DigiArticleContext();
        }

        public Article AddArticle(Article article)
        {
            _context.Add(article);
            _context.SaveChanges();
            return GetArticleById(article.Id);
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public List<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }

        public bool DeleteArticle(int id)
        {
            var response = _context.Remove(_context.Articles.Find(id));
            if (response.State == EntityState.Deleted)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public Article EditArticle(Article article)
        {
            var _entity = _context.Articles.Find(article.Id);
            _entity.Title = article.Title;
            _entity.PublishDate = article.PublishDate;
            _entity.Abstract = article.Abstract;
            var response =_context.Update(_entity);
            if (response.State == EntityState.Modified)
            {
                _context.SaveChanges();
                return _entity;
            }
            else
                return null;
        }
    }
}
