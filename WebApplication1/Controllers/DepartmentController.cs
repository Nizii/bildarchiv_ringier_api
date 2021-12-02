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
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));
            Console.Write(dbClient);

            var dbList = dbClient.GetDatabase("db0132").GetCollection<Department>("imgs").AsQueryable();
            Console.Write(dbList);
            return new JsonResult(dbList);
        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            int LastDepartmentId = dbClient.GetDatabase("db0132").GetCollection<Department>("imgs").AsQueryable().Count();
            dep.ImgId = LastDepartmentId + 1;

            dbClient.GetDatabase("db0132").GetCollection<Department>("imgs").InsertOne(dep);

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var filter = Builders<Department>.Filter.Eq("ImgId", dep.ImgId);

            var update = Builders<Department>.Update.Set("ImgNanme", dep.ImgNanme);



            dbClient.GetDatabase("db0132").GetCollection<Department>("imgs").UpdateOne(filter,update);

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Teambcon"));

            var filter = Builders<Department>.Filter.Eq("ImgId", id);


            dbClient.GetDatabase("db0132").GetCollection<Department>("imgs").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }



    }
}
