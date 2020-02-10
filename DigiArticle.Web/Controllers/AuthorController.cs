using DigiArticle.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DigiArticle.Web.Controllers
{
    public class AuthorController : BaseController
    {
        public AuthorController(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult Index()
        {
            var _returnModel = Get<List<Author>>("GetAuthors");
            return View(_returnModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddAuthor(IFormCollection formCollection)
        {
            var _returnModel = Post<Author>("AddAuthor", new Author
            {
                FirstName = formCollection["FirstName"],
                LastName = formCollection["LastName"],
                MiddleName = formCollection["MiddleName"],
                BirthDate = Convert.ToDateTime(formCollection["BirthDate"]),
                CreationDate = DateTime.Now,
            });
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var _returnModel = Post<bool>("DeleteAuthor", id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var _returnModel = Post<Author>("GetAuthorById", id);
            return View(_returnModel);
        }

        public IActionResult EditAction(IFormCollection formCollection)
        {
            var _returnModel = Post<Author>("EditAuthor", new Author
            {
                FirstName = formCollection["FirstName"],
                LastName = formCollection["LastName"],
                MiddleName = formCollection["MiddleName"],
                BirthDate = Convert.ToDateTime(formCollection["BirthDate"]),
                Id = Convert.ToInt32(formCollection["Id"])
            });
            return RedirectToAction("Index");
        }
    }
}