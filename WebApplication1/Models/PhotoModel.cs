using MongoDB.Bson;
using System;
namespace WebApplication1.Models
{
    public class PhotoModel
    {
        private const string PHOTO_URL = "https://localhost:5000/photos";
        //private const string PHOTO_URL = "https://bildarchivaarau.azurewebsites.net/photos/";

        public ObjectId Id { get; set; }
        public int PhotoId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Filename { get; set; }
        public string Link { get { return PHOTO_URL + Filename; } }
    }
}