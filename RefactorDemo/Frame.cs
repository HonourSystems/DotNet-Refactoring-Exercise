using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorDemo
{
    public class Frame
    {

        public enum FrameStatus
        {
            Open,
            Closed
        }

        private int round;

        private FrameStatus status;

        private string firstRound;
        private string secondRound;
        private string thirdRound;
        private string total;

        private Frame lastFrame;


        public Frame(int round, string first, string second, string third, Frame lastFrame)
        {
            this.Round = round;
            this.firstRound = first;
            this.secondRound = second;
            this.thirdRound = third;
            this.total = "";
            this.status = FrameStatus.Open;
            this.LastFrame = lastFrame;
        }


        public virtual FrameStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
            }
        }






        public virtual string FirstRound
        {
            get
            {
                return firstRound;
            }
            set
            {
                this.firstRound = value;
            }
        }






        public virtual string SecondRound
        {
            get
            {
                return secondRound;
            }
            set
            {
                this.secondRound = value;
            }
        }






        public virtual string ThirdRound
        {
            get
            {
                return thirdRound;
            }
            set
            {
                this.thirdRound = value;
            }
        }






        public virtual string Total
        {
            get
            {
                return total;
            }
            set
            {
                this.total = value;
            }
        }





        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(firstRound).Append("-");
            sb.Append(secondRound).Append("-");
            sb.Append(thirdRound).Append("-");
            sb.Append(total);

            return sb.ToString();
        }


        public virtual int Round
        {
            set
            {
                this.round = value;
            }
            get
            {
                return round;
            }
        }




        public virtual Frame LastFrame
        {
            set
            {
                this.lastFrame = value;
            }
            get
            {
                return lastFrame;
            }
        }



    }
}
