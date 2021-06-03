using FamilyOrgaBack.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FamilyOrgaBack.Services 
{
    public class ArticleService
    {
        private readonly IMongoCollection<Article> _articles;
        public ArticleService(IFamilyOrgaDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _articles = database.GetCollection<Article>(settings.ShoppingListCollectionName);
        }

        public List<Article> Get() => 
            _articles.Find(Article => true).ToList();
        
        public Article Get(string id) =>
            _articles.Find(article => article.Id == id).FirstOrDefault();

        public Article Create(Article article)
        {
            _articles.InsertOne(article);
            return article;
        }
        public void Update(string id, Article articleIn) =>
        _articles.ReplaceOne(article => article.Id == id, articleIn);

        public void Remove(Article artcleIn) =>
        _articles.DeleteOne(article => article.Id == artcleIn.Id);

        public void Remove(string id)=>
        _articles.DeleteOne(article => article.Id == id);
    }
}