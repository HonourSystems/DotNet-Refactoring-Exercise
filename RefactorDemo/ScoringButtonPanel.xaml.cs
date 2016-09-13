using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RefactorDemo
{
    /// <summary>
    /// Interaction logic for ScoringButtonPanel.xaml
    /// </summary>
    public partial class ScoringButtonPanel : UserControl
    {
        public IDictionary<string, PlayerPanel> pnlScoringDisplays { get; set; }

        private string currentPlayer = "";

        public ScoringButtonPanel()
        {
            InitializeComponent();
            currentPlayer = "Player1";
        }

        public ScoringButtonPanel(IDictionary<string, PlayerPanel> map)
            : this()
        {
            pnlScoringDisplays = map;
        }

        private void btnScoreZero_Click(object sender, RoutedEventArgs e)
        {
            btnScoreZeroActionPerformed();
        }

        private void btnScoreOne_Click(object sender, RoutedEventArgs e)
        {
            btnScoreOneActionPerformed();
        }

        private void btnScoreTwo_Click(object sender, RoutedEventArgs e)
        {
            btnScoreTwoActionPerformed();
        }

        private void btnScoreThree_Click(object sender, RoutedEventArgs e)
        {
            btnScoreThreeActionPerformed();
        }

        private void btnScoreFour_Click(object sender, RoutedEventArgs e)
        {
            btnScoreFourActionPerformed();
        }

        private void btnScoreFive_Click(object sender, RoutedEventArgs e)
        {
            btnScoreFiveActionPerformed();
        }

        private void btnScoreSix_Click(object sender, RoutedEventArgs e)
        {
            btnScoreSixActionPerformed();
        }

        private void btnScoreSeven_Click(object sender, RoutedEventArgs e)
        {
            btnScoreSevenActionPerformed();
        }

        private void btnScoreEight_Click(object sender, RoutedEventArgs e)
        {
            btnScoreEightActionPerformed();
        }

        private void btnScoreNine_Click(object sender, RoutedEventArgs e)
        {
            btnScoreNineActionPerformed();
        }

        private void btnScoreStrike_Click(object sender, RoutedEventArgs e)
        {
            btnScoreStrikeActionPerformed();
        }

        private void btnScoreSpare_Click(object sender, RoutedEventArgs e)
        {
            btnScoreSpareActionPerformed();
        }


        private void btnScoreZeroActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "0");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreOneActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "1");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreTwoActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "2");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreThreeActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "3");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreFourActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "4");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreFiveActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "5");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreSixActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "6");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreSevenActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "7");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreEightActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "8");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreNineActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "9");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreStrikeActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "X");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        private void btnScoreSpareActionPerformed()
        {
            Frame score = addScore(this.currentPlayer, "/");
            PlayerPanel pnlScoringDisplay = pnlScoringDisplays[this.currentPlayer];
            pnlScoringDisplay.addFrame(score);
            pnlScoringDisplay.InvalidateVisual();
        }

        public Frame addScore(string playerName, string newScore)
        {

			/*
			 * Basic error handling
			 */
            if (!(newScore.Equals("0") || newScore.Equals("1") || newScore.Equals("2") || newScore.Equals("3") || newScore.Equals("4") || newScore.Equals("5") || newScore.Equals("6") || newScore.Equals("7") || newScore.Equals("8") || newScore.Equals("9") || newScore.Equals("/") || newScore.Equals("X")))
            {
                throw new Exception("Not a valid score.");
            }

			/*
			 * Calculate open or closed and create new Frame if required
			 */

            Player player = pnlScoringDisplays[this.currentPlayer].Player;

            Frame currentScore = null;

            IEnumerator<Frame> i = player.Scores.Reverse().GetEnumerator();
            if (i.MoveNext())
            {
                currentScore = i.Current;
            }
            else
            {
                currentScore = new Frame(1,"","","",currentScore);
                player.Scores.AddLast(currentScore);
            }

            if (currentScore.FirstRound != "")
            {
                if (currentScore.FirstRound == "X" && currentScore.Round != 10)
                {
                    currentScore.Status = Frame.FrameStatus.Closed;
                    int nextFrameRound = currentScore.Round + 1;
                    currentScore = new Frame(nextFrameRound,"","","",currentScore);
                    player.Scores.AddLast(currentScore);
                }
            }

            if (currentScore.SecondRound != "" && currentScore.Round != 10)
            {
                currentScore.Status = Frame.FrameStatus.Closed;
                int nextFrameRound = currentScore.Round + 1;
                currentScore = new Frame(nextFrameRound,"","","",currentScore);
                player.Scores.AddLast(currentScore);
            }
            else if (currentScore.SecondRound != "" && currentScore.Round == 10 && currentScore.ThirdRound != "")
            {
                //end of game.
                return null;
            }

			/*
			 * Begin calculation of frames
			 */
            if (currentScore.FirstRound == "")
            {
                currentScore.FirstRound = newScore;

				/*
				 * Calculate for the Second Round
				 */

                if (currentScore.FirstRound.Equals("0"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(0);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet unless this is the 4th strike in a row.
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }

                }
                if (currentScore.FirstRound.Equals("1"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(1);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.		
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }

                }
                if (currentScore.FirstRound.Equals("2"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(2);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.					
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }
                }
                if (currentScore.FirstRound.Equals("3"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(3);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.				
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }
                }
                if (currentScore.FirstRound.Equals("4"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(4);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.				
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }
                }
                if (currentScore.FirstRound.Equals("5"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(5);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.			
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }
                }
                if (currentScore.FirstRound.Equals("6"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(6);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }
                }
                if (currentScore.FirstRound.Equals("7"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(7);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }
                }
                if (currentScore.FirstRound.Equals("8"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(8);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.	
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }
                }
                if (currentScore.FirstRound.Equals("9"))
                {
                    if (currentScore.LastFrame == null)
                    {
                        currentScore.Total = Convert.ToString(9);

                    }
                    else if (currentScore.LastFrame.SecondRound == "/")
                    {

                        //calculate the total for the spare
                        int lastTotalBeforeSpareFrame = 0;
                        if (currentScore.LastFrame.LastFrame != null)
                        {
                            lastTotalBeforeSpareFrame = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                        }
                        int spareTotal = lastTotalBeforeSpareFrame + 10 + ((int.Parse(currentScore.FirstRound)));
                        currentScore.LastFrame.Total = Convert.ToString(spareTotal);

                        //calculate the total for this frame
                        currentScore.Total = (new int?(spareTotal + ((int.Parse(currentScore.FirstRound))))).ToString();

                    }
                    else if (currentScore.LastFrame.FirstRound == "X")
                    {
                        //Can't calculate yet as strikes are calculated in the second round.				
                    }
                    else
                    {
                        int x = (int.Parse(currentScore.LastFrame.Total));
                        currentScore.Total = (new int?(x + (int.Parse(currentScore.FirstRound)))).ToString();
                    }
                }
                if (currentScore.FirstRound.Equals("X"))
                {

                    if (currentScore.Round > 3 && currentScore.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame.LastFrame.FirstRound.Equals("X"))
                    {

                        //if this is the 4th strike in a row, then calculate the total.
                        //Total score for a frame can never be more than 30.
                        //
                        // X = 30 = (0) + 10 + 10 + 10
                        // X = ?  = (30) + 10 + 10 + (?+?) )
                        // X = ?  = (30) + 10 + (?+?) )
                        // X = ?  = (30) + (?+?) )
                        // ?-?
                        //
                        // OR
                        //
                        // 7-1 = 8  = (0) + (7+1)
                        // X   = 38 = (8) + 10 + 10 + 10
                        // X   = ?  = (38) + 10 + 10 + (?+?) )
                        // X   = ?  = (^) + 10 + (?+?) )
                        // X   = ?  = (^) + 10 + (?+?) )
                        // ?-? =

                        if (currentScore.LastFrame.LastFrame.LastFrame.LastFrame == null)
                        {
                            currentScore.LastFrame.LastFrame.LastFrame.Total = (new int?(30)).ToString();
                        }
                        else
                        {
                            int totalBeforeThreeStrikes = (int.Parse(currentScore.LastFrame.LastFrame.LastFrame.LastFrame.Total));
                            currentScore.LastFrame.LastFrame.LastFrame.Total = (new int?(totalBeforeThreeStrikes + 30)).ToString();
                        }
                    }
                }

                if (currentScore.FirstRound.Equals("/"))
                {
                    throw new Exception("Can't have spare on first round");
                }

            }
            else if (currentScore.SecondRound.Equals(""))
            {
                /// <summary>
                /// Calculate for the Second Round
                /// On the 10th frame, can have two bonus points.
                /// However this only happens if the user gets a strike or a spare.
                /// </summary>
                if (currentScore.FirstRound.Equals("X") && currentScore.Round != 10)
                {
                    throw new Exception("Can't have strike on second round, unless in the 10th frame");
                }
                else if (currentScore.FirstRound.Equals("X") && currentScore.Round == 10)
                {
                    currentScore.SecondRound = newScore;
                    return currentScore;
                }

                if (newScore.Equals("/"))
                {
                    currentScore.SecondRound = "/";
                    secondRoundCalc(currentScore);
                    return currentScore;
                }

                int secondRound = (int.Parse(currentScore.FirstRound));
                secondRound = (int.Parse(newScore)) - secondRound;
                currentScore.SecondRound = (new int?(secondRound)).ToString();
                if (currentScore.SecondRound.Equals("0"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("1"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("2"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("3"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("4"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("5"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("6"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("7"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("8"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }
                if (currentScore.SecondRound.Equals("9"))
                {

                    secondRoundCalc(currentScore);

                    if (currentScore.Round < 10)
                    {
                        currentScore.Status = Frame.FrameStatus.Closed;
                    }

                }

            }
            else
            {
                /// <summary>
                /// Calculate for the Third Round, only valid in round 10, if first is a strike, or spare
                /// </summary>

                if (currentScore.Round != 10)
                {
                    throw new Exception("Can't have third round in a frame unless in the 10th frame");
                }
                else if (!currentScore.FirstRound.Equals("X") && !currentScore.SecondRound.Equals("/"))
                {
                    throw new Exception("Can't have a third round unless a spare or strike happened");
                }

				/*
				 * Calculate total for the frame.
				 * Scenarios:
				 * Invalid										n n 
				 * 
				 * A Triple Strike									X X X   Total for frame = (10 + (10 + 10)
				 * B A single point after a double strike			X X n   Total for frame = 10 + 10 + n
				 * C A second point after strike in first round		X n n	Total for frame = (10 + (n+n))
				 * D A spare following a strike in the first round	X n /	Total for frame = (10 + (10))
				 * E A single point after a spare					n / n	Total for frame = (10 + n) + n
				 * F A strike after a spare							n / X
				 */
                currentScore.ThirdRound = newScore;

                int frame10TotalScore = 0;
                int frame10RoundOne = 0;
                char scenario;
                if (newScore.Equals("0") || newScore.Equals("1") || newScore.Equals("2") || newScore.Equals("3") || newScore.Equals("4") || newScore.Equals("5") || newScore.Equals("6") || newScore.Equals("7") || newScore.Equals("8") || newScore.Equals("9"))
                {
                    // B or C or E
                    if (currentScore.LastFrame.SecondRound.Equals("X"))
                    {
                        // B
                        scenario = 'B';
                        frame10TotalScore = 10 + 10 + int.Parse(newScore);
                        frame10RoundOne = 10;
                    }
                    else if (currentScore.LastFrame.SecondRound.Equals("0") || currentScore.LastFrame.SecondRound.Equals("1") || currentScore.LastFrame.SecondRound.Equals("2") || currentScore.LastFrame.SecondRound.Equals("3") || currentScore.LastFrame.SecondRound.Equals("4") || currentScore.LastFrame.SecondRound.Equals("5") || currentScore.LastFrame.SecondRound.Equals("6") || currentScore.LastFrame.SecondRound.Equals("7") || currentScore.LastFrame.SecondRound.Equals("8") || currentScore.LastFrame.SecondRound.Equals("9"))
                    {
                        // C  Total for frame = (10 + (n+n))
                        scenario = 'C';
                        frame10TotalScore = 10 + (int.Parse(currentScore.SecondRound)) + (int.Parse(currentScore.ThirdRound));
                        frame10RoundOne = int.Parse(newScore);
                    }
                    else
                    {
                        // E Total for frame = (10 + n)
                        scenario = 'E';
                        frame10TotalScore = 10 + (int.Parse(currentScore.ThirdRound)) + (int.Parse(currentScore.ThirdRound));
                        frame10RoundOne = (int.Parse(currentScore.FirstRound));
                    }

                }
                else if (newScore.Equals("X"))
                {
                    // A or F
                    if (currentScore.SecondRound.Equals("/"))
                    {
                        //F
                        scenario = 'F';
                        frame10TotalScore = 20;
                        frame10RoundOne = (int.Parse(currentScore.FirstRound));
                    }
                    else
                    {
                        //A
                        scenario = 'A';
                        frame10TotalScore = 30;
                        frame10RoundOne = 10;
                    }

                }
                else if (newScore.Equals("/"))
                {
                    //D 
                    scenario = 'D';
                    frame10TotalScore = 20;
                    frame10RoundOne = 10;
                }

                // Need to handle strikes a run of strikes. 
                // Will have calculated to frame 6 already.
                // Will need to check for frame 8 and 9 and then calculate them.

                //  	Frame 7 	Frame 8		Frame 9		Frame 10
                //  A	X			X 			X			x x x | x n n | n / n
                //  B	n			X 			X			x x x | x n n | n / n
                //  C	n			n			X			x x x | x n n | n / n
                //	D	n			n			n			x x x | x n n | n / n
                //	E	n			n			n /			x x x | x n n | n / n

                if (currentScore.LastFrame.SecondRound.Equals("/"))
                {
                    int total = frame10RoundOne + (int.Parse(currentScore.LastFrame.LastFrame.Total));
                    currentScore.LastFrame.Total = (new int?(total)).ToString();

                }
                else if (currentScore.FirstRound.Equals("X") && !currentScore.ThirdRound.Equals("/") && currentScore.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame.FirstRound.Equals("X"))
                {
                        //detected 2 strikes in a row, so calculate and set.

                    int frame7Total = (int.Parse(currentScore.LastFrame.LastFrame.LastFrame.Total));
                    int strikeFrame8 = frame7Total + 10 + frame10RoundOne;
                    int strikeFrame9 = strikeFrame8 + 10 + frame10TotalScore;
                    int strikeFrame10 = strikeFrame9 + frame10TotalScore;

                    currentScore.LastFrame.LastFrame.Total = (new int?(strikeFrame8)).ToString();
                    currentScore.LastFrame.Total = (new int?(strikeFrame9)).ToString();
                    currentScore.Total = (new int?(strikeFrame10)).ToString();

                }
                else if (currentScore.SecondRound.Equals("/") && currentScore.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame.FirstRound.Equals("X"))
                {

                    int frame6Total = (int.Parse(currentScore.LastFrame.LastFrame.LastFrame.LastFrame.Total));
                    int strikeFrame7 = frame6Total + 10 + 10 + 10;
                    int strikeFrame8 = strikeFrame7 + 10 + 10 + frame10RoundOne;
                    int strikeFrame9 = strikeFrame8 + 10 + 10;
                    int strikeFrame10 = 0;
                    if (newScore.Equals("X"))
                    {
                        strikeFrame10 = strikeFrame9 + 20;
                    }
                    else
                    {
                        strikeFrame10 = strikeFrame9 + 10 + (int.Parse(newScore));
                    }


                    currentScore.LastFrame.LastFrame.Total = (new int?(strikeFrame8)).ToString();
                    currentScore.LastFrame.Total = (new int?(strikeFrame9)).ToString();
                    currentScore.Total = (new int?(strikeFrame10)).ToString();

                }
                else if (currentScore.FirstRound.Equals("X") && currentScore.ThirdRound.Equals("/") && currentScore.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame.FirstRound.Equals("X"))
                {
                    // detected 2 strikes, before this strike and spare

                    int frame7Total = (int.Parse(currentScore.LastFrame.LastFrame.LastFrame.Total));
                    int strikeFrame8 = frame7Total + 30;
                    int strikeFrame9 = strikeFrame8 + 10 + 10 + int.Parse(currentScore.SecondRound);
                    int strikeFrame10 = strikeFrame9 + frame10TotalScore;

                    currentScore.LastFrame.LastFrame.Total = (new int?(strikeFrame8)).ToString();
                    currentScore.LastFrame.Total = (new int?(strikeFrame9)).ToString();
                    currentScore.Total = (new int?(strikeFrame10)).ToString();

                }
                else if (currentScore.FirstRound.Equals("X") && currentScore.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame.FirstRound.Equals("X"))
                {
                    // detected 2 strikes

                    int frame7Total = (int.Parse(currentScore.LastFrame.LastFrame.LastFrame.Total));
                    int strikeFrame8 = frame7Total + 30;
                    int strikeFrame9 = strikeFrame8 + 10 + frame10TotalScore;
                    int strikeFrame10 = strikeFrame9 + int.Parse(currentScore.FirstRound) + int.Parse(currentScore.SecondRound);

                    currentScore.LastFrame.LastFrame.Total = (new int?(strikeFrame8)).ToString();
                    currentScore.LastFrame.Total = (new int?(strikeFrame9)).ToString();
                    currentScore.Total = (new int?(strikeFrame10)).ToString();

                }
                else if (currentScore.FirstRound.Equals("X") && currentScore.LastFrame.FirstRound.Equals("X"))
                {

                    // detected 1 strike
                    int frame8Total = (int.Parse(currentScore.LastFrame.LastFrame.Total));
                    int strikeFrame9 = frame8Total + 10 + frame10TotalScore;
                    int strikeFrame10 = strikeFrame9 + frame10TotalScore;

                    currentScore.LastFrame.Total = (new int?(strikeFrame9)).ToString();
                    currentScore.Total = (new int?(strikeFrame10)).ToString();
                }
                currentScore.Status = Frame.FrameStatus.Closed;
            }
            return currentScore;
        }

        /// 
        /// <param name="currentScore"> </param>
        private void secondRoundCalc(Frame currentScore)
        {

            int thisFrame;
            if (currentScore.SecondRound.Equals("/"))
            {
                thisFrame = 10;
            }
            else
            {
                thisFrame = (int.Parse(currentScore.FirstRound)) + (int.Parse(currentScore.SecondRound));
            }


            if (currentScore.LastFrame == null)
            {
                //first frame of the game, so just set to the  frame's score.
                int x = (int.Parse(currentScore.FirstRound)) + (int.Parse(currentScore.SecondRound));
                currentScore.Total = Convert.ToString(x);

            }
            else if (currentScore.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame != null && currentScore.LastFrame.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame.LastFrame != null && currentScore.LastFrame.LastFrame.LastFrame.FirstRound.Equals("X"))
            {
                        //detected 3 strikes in a row, so calculate and set.

						/*
						 * The most points that can be scored in a single frame is 30 points (10 for the original strike, plus strikes in the two subsequent frames).
						 * 
						 * A turkey's pinfall is:
						 * Frame 1, ball 1: 10 pins (Strike)
						 * Frame 2, ball 1: 10 pins (Strike)
						 * Frame 3, ball 1: 10 pins (Strike)
						 * Frame 4, ball 1: 1 pins (Gutterball)
						 * Frame 4, ball 2: 8 pins
						 * 
						 * The total score from these throws is:
						 * Frame one:   10 + (10 + 10)  = 30  Total = 30
						 * Frame two:   10 + (10 + X+Y) = 29  Total = 59
						 * Frame three: 10 + (X+Y)      = 19  Total = 78 
						 * Frame four:  X+Y = 1+8       = 9   Total = 87
						 */

                string beforeStrikeOne = "0";
                if (currentScore.LastFrame.LastFrame.LastFrame.LastFrame != null)
                {
                    beforeStrikeOne = currentScore.LastFrame.LastFrame.LastFrame.LastFrame.Total;
                }
                int strikeOneTotal = (int.Parse(beforeStrikeOne)) + 10 + 10 + 10;
                int strikeTwoTotal = strikeOneTotal + 10 + 10 + thisFrame;
                int strikeThreeTotal = strikeTwoTotal + 10 + thisFrame;
                int currentTotal = strikeThreeTotal + thisFrame;

                currentScore.LastFrame.LastFrame.LastFrame.Total = (new int?(strikeOneTotal)).ToString();
                currentScore.LastFrame.LastFrame.Total = (new int?(strikeTwoTotal)).ToString();
                currentScore.LastFrame.Total = (new int?(strikeThreeTotal)).ToString();
                if (!currentScore.SecondRound.Equals("/"))
                {
                    currentScore.Total = (new int?(currentTotal)).ToString();
                }

            }
            else if (currentScore.LastFrame.FirstRound.Equals("X") && currentScore.LastFrame.LastFrame != null && currentScore.LastFrame.LastFrame.FirstRound.Equals("X"))
            {
                        //detected 2 strikes in a row, so calculate and set.

						/*
						 * The most points that can be scored in a single frame is 30 points (10 for the original strike, plus strikes in the two subsequent frames).
						 * 
						 * A turkey's pinfall is:
						 * Frame 2, ball 1: 10 pins (Strike)
						 * Frame 3, ball 1: 10 pins (Strike)
						 * Frame 4, ball 1: 1 pins (Gutterball)
						 * Frame 4, ball 2: 8 pins
						 * 
						 * The total score from these throws is:
						 * Frame two:   10 + (10 + X+Y) = 29  Total = 29
						 * Frame three: 10 + (X+Y)      = 19  Total = 48 
						 * Frame four:  X+Y = 1+8       = 9   Total = 57
						 */

                string beforeStrikeOne = "0";
                if (currentScore.LastFrame.LastFrame.LastFrame != null)
                {
                    beforeStrikeOne = currentScore.LastFrame.LastFrame.LastFrame.Total;
                }
                int strikeOneTotal = (int.Parse(beforeStrikeOne)) + 10 + 10 + thisFrame;
                int strikeTwoTotal = strikeOneTotal + 10 + thisFrame;
                int currentTotal = strikeTwoTotal + thisFrame;

                currentScore.LastFrame.LastFrame.Total = (new int?(strikeOneTotal)).ToString();
                currentScore.LastFrame.Total = (new int?(strikeTwoTotal)).ToString();
                if (!currentScore.SecondRound.Equals("/"))
                {
                    currentScore.Total = (new int?(currentTotal)).ToString();
                }

            }
            else if (currentScore.LastFrame.FirstRound.Equals("X"))
            {
                // detected 1 strike
				/*
				 * Frame four: X+Y = 1+8 = 9 Total = 57
				 */

                string beforeStrikeOne = "0";
                if (currentScore.LastFrame.LastFrame != null)
                {
                    beforeStrikeOne = currentScore.LastFrame.LastFrame.Total;
                }
                int strikeOneTotal = (int.Parse(beforeStrikeOne)) + 10 + thisFrame;
                int currentTotal = strikeOneTotal + thisFrame;

                currentScore.LastFrame.Total = (new int?(strikeOneTotal)).ToString();
                if (!currentScore.SecondRound.Equals("/"))
                {
                    currentScore.Total = (new int?(currentTotal)).ToString();
                }

            }
            else if (!currentScore.SecondRound.Equals("/"))
            {
                int x = (int.Parse(currentScore.LastFrame.Total));
                x = x + thisFrame;
                currentScore.Total = Convert.ToString(x);
            }
        }

        public void togglecurrentplayer()
        {
            if (this.currentPlayer == "Player1")
            {
                this.currentPlayer = "Player2";
            }
            else
            {
                this.currentPlayer = "Player1";
            }
        }
    }
}
