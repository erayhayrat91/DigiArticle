using DigiArticle.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiArticle.Entity.Interfaces
{
    public interface IArticle
    {
        List<Article> GetArticles();
        Article GetArticleById(int id);
        Article AddArticle(Article article);
        bool DeleteArticle(int id);
        Article EditArticle(Article article);
    }
}