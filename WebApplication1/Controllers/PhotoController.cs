using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        //private readonly IWebHostEnvironment _env;
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
       
        [HttpPost]
        public JsonResult Post(PhotoModel pm)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            int LastPhotoId = dbClient.GetDatabase("db0132").GetCollection<PhotoModel>("Photos").AsQueryable().Count();
            pm.PhotoId = LastPhotoId + 1;

            dbClient
                .GetDatabase("db0132")
                .GetCollection<PhotoModel>("Photos")
                .InsertOne(pm);

            return new JsonResult("Added Successfully");
        }

        /*
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.Filename;
                //var physicalPath = _env.ContentRootPath + "/Photos/" + filename;
     
                //var physicalPath = "C:/Users/nizam/Desktop/WebExtendet/Projekt/api/WebApplication1/WebApplication1/Photos/" + filename;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
        

        [HttpPut]
        public JsonResult Put(PhotoModel pm)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var filter = Builders<PhotoModel>.Filter.Eq("PhotoId", pm.PhotoId);

            var update = Builders<PhotoModel>.Update.Set("Name", pm.Name)
                                                    .Set("Description", pm.Description)
                                                    .Set("With", pm.Width)
                                                    .Set("Height",pm.Height)
                                                    .Set("Filename", pm.Filename);
            
            dbClient.GetDatabase("db0132").GetCollection<PhotoModel>("Photos").UpdateOne(filter, update);

            return new JsonResult("Updated Successfully");
        }
        */

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var filter = Builders<PhotoModel>.Filter.Eq("PhotoId", id);


            dbClient.GetDatabase("db0132").GetCollection<PhotoModel>("Photos").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }



    }
}

