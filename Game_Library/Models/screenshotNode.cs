using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Game_Library.Models
{
    public class screenshotNode
    {
        public string imgPath {  get; set; }
        public string description { get; set; }
        public string title { get; set; }


        public DateTime datePosted { get; set; }

        public screenshotNode(string title, string imgPath, DateTime datePosted, string description =" ")
        {
            this.title = title;
            this.imgPath = imgPath;
            this.description = description;
            this.datePosted = datePosted;
        }
    }
}
