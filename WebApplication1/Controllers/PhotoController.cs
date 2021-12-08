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
    public class PhotoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PhotoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var dbList = dbClient
                .GetDatabase("db0132")
                .GetCollection<PhotoModel>("Photos")
                .AsQueryable();

            return new JsonResult(dbList);
        }
        /*
        [HttpPost]
        public JsonResult Post(ImgModel im)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            int LastImgId = dbClient.GetDatabase("db0132").GetCollection<PhotoController>("Photos").AsQueryable().Count();
            im.ImgId = LastImgId + 1;

            dbClient.GetDatabase("db0132").GetCollection<ImgModel>("Photos").InsertOne(im);

            return new JsonResult("Added Successfully");
        }
        
        [HttpPut]
        public JsonResult Put(ImgModel im)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var filter = Builders<PhotoModel>.Filter.Eq("ImgId", im.ImgId);

            var update = Builders<PhotoModel>.Update.Set("ImgName", im.ImgName);



            dbClient.GetDatabase("db0132").GetCollection<PhotoModel>("Photos").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }
        */

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var filter = Builders<PhotoModel>.Filter.Eq("PhotoID", id);


            dbClient.GetDatabase("db0132").GetCollection<PhotoModel>("Photos").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }



    }
}

