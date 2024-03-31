using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using socialnetwork.Models;

namespace socialnetwork.Controllers
{
    public class ArticleController
    {
        private readonly IConfiguration _configuration;
        public ArticleController(IConfiguration configuration)

        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddArticle")]
        public Response AddArticle(Article article)
        {
            Response response = new Response();

           
            SqlConnection conneciton = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
           Dal dal = new Dal();
            response = dal.AddArticle(article, conneciton); 

            
            return response;
        }

        [HttpPost]
        [Route("ArticleList")]
        public Response ArticleList(Article article)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleList(article,connection);
            return response;
        
        }
        [HttpPost]
        [Route("ArticleApproval")]
        public Response UserApproval(Article article)
        {

            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleApproval(article, connection);
            return response;
        }
    }
}
