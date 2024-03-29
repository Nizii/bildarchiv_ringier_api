﻿using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public PhotoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Holt Documents aus derDatenbank
        // @return gibt Liste zurück mit allen Einträgen aus der Datenebank
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

        // Setzt neue Documents in der Datenbank
        // @Param empfängt ein PhotoModel Objekt
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

        // Lädt Bild hoch
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;
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

        // Aendert ein Document in der Datenbank
        // @Param empfängt ein PhotoModel Objekt
        [HttpPut]
        public JsonResult Put(PhotoModel pm)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));
            var filter = Builders<PhotoModel>.Filter.Eq("PhotoId", pm.PhotoId);
            var update = Builders<PhotoModel>.Update.Set("PhotoId", pm.PhotoId)
                                                    .Set("Category", pm.Category)
                                                    .Set("Size", pm.Size)
                                                    .Set("Filename", pm.Filename)
                                                    .Set("Copyright", pm.Copyright)
                                                    .Set("Filetext", pm.Filetext)
                                                    .Set("Haschild", pm.Haschild)
                                                    .Set("Title", pm.Title);
            dbClient.GetDatabase("db0132").GetCollection<PhotoModel>("Photos").UpdateOne(filter, update);
            return new JsonResult("Updated Successfully");
        }
        
        // Löscht ein Document aus der Datenbank anhand der ID
        // @Param empfängt Id des zu loeschenden Bild
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

