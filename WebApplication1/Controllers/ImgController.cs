using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ImgController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            Console.WriteLine("Test");
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));
            Console.WriteLine(dbClient);
            var result = dbClient
                .GetDatabase("db0132")
                .GetCollection<ImgModel>("Imgs")
                .AsQueryable();

            return new JsonResult(result);
        }

        [HttpPost]
        public JsonResult Post(ImgModel im)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            int LastDepartmentId = dbClient.GetDatabase("db0132").GetCollection<ImgModel>("Imgs").AsQueryable().Count();
            im.ImgId = LastDepartmentId + 1;

            dbClient.GetDatabase("db0132").GetCollection<ImgModel>("Imgs").InsertOne(im);

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(ImgModel im)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var filter = Builders<ImgModel>.Filter.Eq("ImgId", im.ImgId);

            var update = Builders<ImgModel>.Update.Set("ImgName", im.ImgName);



            dbClient.GetDatabase("db0132").GetCollection<ImgModel>("Imgs").UpdateOne(filter,update);

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var filter = Builders<ImgModel>.Filter.Eq("ImgId", id);


            dbClient.GetDatabase("db0132").GetCollection<ImgModel>("Imgs").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }



    }
}
