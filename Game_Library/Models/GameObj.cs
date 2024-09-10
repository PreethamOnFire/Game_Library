using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<screenshotNode> screenshotNodes { get; set; }

        public GameObj(string Name, string executablePath, string logoPath, ObservableCollection<screenshotNode> screenshotNodes, bool isFinished = false)
        {
            this.Name = Name;
            this.isFinished = isFinished;
            this.executablePath = executablePath;
            this.logoPath = logoPath;
            this.screenshotNodes = screenshotNodes;
        }

        public override string ToString()
        {
            string str = Name + "\t" + executablePath + "\t" + logoPath + "\t" + isFinished.ToString();
            return str;
        }
    }
    
   
}
