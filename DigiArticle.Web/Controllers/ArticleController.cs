using DigiArticle.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DigiArticle.Web.Controllers
{
    public class ArticleController : BaseController
    {
        public ArticleController(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult Index()
        {
            var _returnModel = Get<List<Article>>("GetArticles");
            return View(_returnModel);
        }

        public IActionResult Create()
        {
            var _returnModel = Get<List<Author>>("GetAuthors","Author");
            var _selectList = new List<SelectListItem>();
            foreach (var item in _returnModel)
            {
                _selectList.Add(new SelectListItem { Text = item.FirstName + " " + item.LastName, Value = item.Id.ToString() });
            }
            var tuple = new Tuple<Article, List<SelectListItem>>(new Article(), _selectList);
            return View(tuple);
        }

        public IActionResult AddArticle(IFormCollection formCollection)
        {
            var _returnModel = Post<Article>("AddArticle", new Article
            {
                Abstract = formCollection["Item1.Abstract"],
                Title = formCollection["Item1.Title"],
                PublishDate = Convert.ToDateTime(formCollection["Item1.PublishDate"]),
                CreationDate = DateTime.Now,
                AuthorId = Convert.ToInt32(formCollection["Item1.AuthorId"])
            });
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var _return = Post<bool>("DeleteArticle", id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var _return = Post<Article>("GetArticleById", id);
            return View(_return);
        }

        public IActionResult EditAction(IFormCollection formCollection)
        {
            var _return = Post<Article>("EditArticle", new Article
            {
                Abstract = formCollection["Abstract"],
                Title = formCollection["Title"],
                PublishDate = Convert.ToDateTime(formCollection["PublishDate"]),
                Id = Convert.ToInt32(formCollection["Id"])
            });
            return RedirectToAction("Index");
        }
    }
}