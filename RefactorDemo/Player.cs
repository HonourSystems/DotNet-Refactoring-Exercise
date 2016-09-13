using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorDemo
{
    public class Player
    {

        private LinkedList<Frame> scores;
        private string name;

        public Player()
        {
            Scores = new LinkedList<Frame>();
            Name = "ENTER NAME";
        }

        public virtual LinkedList<Frame> Scores
        {
            set
            {
                this.scores = value;
            }
            get
            {
                return scores;
            }
        }


        public virtual string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return name;
            }
        }


    }
}
