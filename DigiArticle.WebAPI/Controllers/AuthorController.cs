using DigiArticle.Entity.Entities;
using DigiArticle.Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigiArticle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthor _author;

        public AuthorController(IAuthor author)
        {
            _author = author;
        }

        [Route("GetAuthors")]
        [HttpGet]
        public ActionResult<List<Author>> GetAuthors()
        {
            return _author.GetAuthors();
        }

        [Route("GetAuthorById")]
        [HttpPost]
        public ActionResult<Author> GetAuthorById([FromBody]int id)
        {
            return _author.GetAuthorById(id);
        }

        [Route("GetAuthorName")]
        [HttpPost]
        public ActionResult<string> GetAuthorName([FromBody]int id)
        {
            return _author.GetAuthorName(id);
        }

        [Route("AddAuthor")]
        [HttpPost]
        public ActionResult<Author> AddAuthor([FromBody]Author author)
        {
            return _author.AddAuthor(author);
        }

        [Route("EditAuthor")]
        [HttpPost]
        public ActionResult<Author> EditAuthor([FromBody]Author author)
        {
            return _author.EditAuthor(author);
        }

        [Route("DeleteAuthor")]
        [HttpPost]
        public ActionResult<bool> DeleteAuthor([FromBody]int id)
        {
            return _author.DeleteAuthor(id);
        }
    }
}