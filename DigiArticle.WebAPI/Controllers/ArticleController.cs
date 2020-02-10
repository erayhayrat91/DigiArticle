using DigiArticle.Entity.Entities;
using DigiArticle.Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigiArticle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        IArticle _article;

        public ArticleController(IArticle Article)
        {
            _article = Article;
        }

        [Route("GetArticles")]
        [HttpGet]
        public ActionResult<List<Article>> GetArticles()
        {
            return _article.GetArticles();
        }

        [Route("GetArticleById")]
        [HttpPost]
        public ActionResult<Article> GetArticleById([FromBody]int id)
        {
            return _article.GetArticleById(id);
        }

        [Route("AddArticle")]
        [HttpPost]
        public ActionResult<Article> AddArticle([FromBody]Article Article)
        {
            return _article.AddArticle(Article);
        }

        [Route("DeleteArticle")]
        [HttpPost]
        public ActionResult<bool> DeleteArticle([FromBody]int id)
        {
            return _article.DeleteArticle(id);
        }

        [Route("EditArticle")]
        [HttpPost]
        public ActionResult<Article> EditArticle([FromBody]Article article)
        {
            return _article.EditArticle(article);
        }
    }
}