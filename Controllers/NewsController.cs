using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using socialnetwork.Models;
namespace socialnetwork.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NewsController
    {
        private readonly IConfiguration _configuration;
        public NewsController(IConfiguration configuration)

        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddNews")]
        public Response AddNews(News news)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Dal dal = new Dal();
            response = dal.AddNews(news, connection);
            return response;
        }

        [HttpGet]
        [Route("NewsList")]
        public Response NewsList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            Dal dal = new Dal();
            response = dal.NewsList(connection);
            return response;
        }
    }
} 
