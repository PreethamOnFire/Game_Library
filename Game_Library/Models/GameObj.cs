using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library.Models
{
    public class GameObj
    {
        public string executablePath {  get; set; }
        public bool isFinished { get; set; }
        public string Name { get; set; }
        public string logoPath {  get; set; }

        public GameObj(string Name, string executablePath, string logoPath, bool isFinished = false)
        {
            this.Name = Name;
            this.isFinished = isFinished;
            this.executablePath = executablePath;
            this.logoPath = logoPath;
        }

        public override string ToString()
        {
            string str = Name + "\t" + executablePath + "\t" + logoPath + "\t" + isFinished.ToString();
            return str;
        }
    }
    
   
}
