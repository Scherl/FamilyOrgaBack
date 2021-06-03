using FamilyOrgaBack.Models;
using FamilyOrgaBack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FamilyOrgaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase{
        private readonly ArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public ActionResult<List<Article>> Get() =>
            _articleService.Get();

        [HttpGet("{id:length(24)}", Name ="GetArticle")]
        public ActionResult<Article> GetActionResult(string id)
        {
            var article = _articleService.Get(id);

            if (article == null)
            {
                return NotFound();
            }
            return article;
        }

        [HttpPost]
        public ActionResult<Article> Create (Article article)
        {
            _articleService.Create(article);
            return CreatedAtRoute("GetArticle", new {id = article.Id.ToString()}, article);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Article articleIn)
        {
            var article = _articleService.Get(id);
            if(article == null)
            {
                return NotFound();
            }
            _articleService.Update(id, articleIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult<List<Article>> Delete(string id)
        {
            var article = _articleService.Get(id);
            if(article == null)
            {
                return NotFound();
            }
            _articleService.Remove(article.Id);
            
            List<Article> ArticlesList = new List<Article>();
            
            ArticlesList = _articleService.Get();


            return ArticlesList;
        }

    }
}