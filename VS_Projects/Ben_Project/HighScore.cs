using System;

namespace Ben_Project
{
    public class HighScore
    {
        public decimal score { get; set; }
        public string name { get; set; }

        public HighScore()
        {

        }

        public HighScore(string name, decimal score)
        {
            this.name = name;
            this.score = score;
        }



    }
}
