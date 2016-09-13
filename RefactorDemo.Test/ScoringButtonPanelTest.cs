using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RefactorDemo.Test
{
    [TestClass]
    public class ScoringButtonPanelTest
    {

        /*
	     * See the following on-line calculator
	     * http://tralvex.com/pub/bowling/BSC.htm
	     */
	
	
	    ScoringButtonPanel panel;
	
        [TestInitialize]
	    public void setup() {
		    PlayerPanel panel1 = new PlayerPanel("Player1");
		    PlayerPanel panel2 = new PlayerPanel("Player2");
		    var map = new Dictionary<String,PlayerPanel>();
		    map[panel1.Player.Name] = panel1;
		    map[panel2.Player.Name] = panel2;
		
		    panel = new ScoringButtonPanel(map);
	    }

	    [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
	    public void testUpdateBadNumber() {
		    panel.addScore("Player1","badtext");
	    }
	
	    [TestMethod]
	    public void testFirstScore_Number() {
		    Frame score = panel.addScore("Player1","6");
		    Assert.AreEqual("6---6", score.ToString());

		    panel.addScore("Player1","9");
		    Assert.AreEqual("6-3--9", score.ToString());
	    }

	    [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
	    public void testFirstScore_SpareOnFirstRoundThowsError() {
		    Frame score = panel.addScore("Player1","/");
	    }
	
	    [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
	    public void testStrikeOnSecondRoundThrowsError() {
		    Frame score = panel.addScore("Player1","9");
		    Assert.AreEqual("9---9", score.ToString());
		    panel.addScore("Player1","X");
	    }
	
	    [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
	    public void testFirstScore_Spare() {
		    Frame score = panel.addScore("Player1","/");
	    }
	
	    [TestMethod]
	    public void testSecondScore_Spare() {
		    Frame score = panel.addScore("Player1","8");
		    Assert.AreEqual("8---8", score.ToString());

		    score = panel.addScore("Player1","9");
		    Assert.AreEqual("8-1--9", score.ToString());
		
		    score = panel.addScore("Player1","1");
		    Assert.AreEqual("1---10", score.ToString());

		    score = panel.addScore("Player1","/");
		    Assert.AreEqual("1-/--10", score.ToString());
		
		    score = panel.addScore("Player1","5");
		    Assert.AreEqual("5---29", score.ToString());
		
		    score = panel.addScore("Player1","6");
		    Assert.AreEqual("5-1--30", score.ToString());
		
	    }
	
	    [TestMethod]
	    public void testOneStrike() {
		    Frame score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---", score.ToString());
		
		    score = panel.addScore("Player1","5");
		    Assert.AreEqual("5---", score.ToString());

		    score = panel.addScore("Player1","6");
		    Assert.AreEqual("5-1--22", score.ToString());
		    Assert.AreEqual("16",score.LastFrame.Total);
	    }
	
	    [TestMethod]
	    public void testTwoStrikesInARow() {
		    Frame score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---", score.ToString());
		
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---", score.ToString());

		    score = panel.addScore("Player1","1");
		    Assert.AreEqual("1---", score.ToString());
		
		    score = panel.addScore("Player1","2");
		    Assert.AreEqual("X---22", score.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---34", score.LastFrame.ToString());
		    Assert.AreEqual("1-1--36", score.ToString());
		
	    }
	
	    [TestMethod]
	    public void testStrikeFollowedBy_Spare() {
		    //1.1
		    Frame score = panel.addScore("Player1","1");
		    Assert.AreEqual("1---1", score.ToString());
		    //1.2
		    score = panel.addScore("Player1","3");
		    Assert.AreEqual("1-2--3", score.ToString());
		
		    //2.1
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---", score.ToString());
		
		    //3.1
		    score = panel.addScore("Player1","1");
		    Assert.AreEqual("1---", score.ToString());
		    //3.2
		    score = panel.addScore("Player1","/");
		    Assert.AreEqual("1-2--3", score.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---23", score.LastFrame.ToString());
		    Assert.AreEqual("1-/--", score.ToString());
		
		    //4.1
		    score = panel.addScore("Player1","5");
		    Assert.AreEqual("1-/--38", score.LastFrame.ToString());
		    Assert.AreEqual("5---43", score.ToString());
		    //4.2
		    score = panel.addScore("Player1","6");
		    Assert.AreEqual("5-1--44", score.ToString());
	    }
	
	    /*
	     * Calculate total for the frame.
	     * Scenarios:
	     * Invalid  n n / | n n X | n n n
	     * 
	     *- A Triple Strike									X X X   Total for frame = (10 + (10 + 10)
	     * B A single point after a double strike			X X n   Total for frame = 10 + 10 + n
	     * C A second point after strike in first round		X n n	Total for frame = (10 + (n+n))
	     *- D A spare following a strike in the first round	X n /	Total for frame = (10 + (10))
	     *- E A single point after a spare					n / n	Total for frame = (10 + n)
	     *- F A strike after a spare							n / X
	     */
	
	    [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
	    public void testInvalidThirdRound() {
		    //Frame:	1	2	3	4	5	6	7	8	9	10
		    //Score:	30	60	90	120	150	180	210	231	243	245
		
		    Frame score = panel.addScore("Player1","X");
		    score = panel.addScore("Player1","X");//2
		    score = panel.addScore("Player1","X");//3
		    score = panel.addScore("Player1","X");//4
		    score = panel.addScore("Player1","X");//5
		    score = panel.addScore("Player1","X");//6
		    score = panel.addScore("Player1","X");//7
		    score = panel.addScore("Player1","X");//8
		    score = panel.addScore("Player1","X");//9
		
		    //10.1
		    score = panel.addScore("Player1","1");
		    Assert.AreEqual("1---", score.ToString());

		    //10.2
		    score = panel.addScore("Player1","2");
		    Assert.AreEqual("1-1--245", score.ToString());

		    //10.3
		    score = panel.addScore("Player1","/");
		    //should throw error
	    }
	
	    [TestMethod]
	    public void testPerfectScoreAddsTo300_A() {
		    //1
		    Frame score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---",score.ToString());

		    //2
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---", score.LastFrame.ToString());
		    Assert.AreEqual("X---", score.ToString());
		
		    //3
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---", score.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.LastFrame.ToString());
		    Assert.AreEqual("X---", score.ToString());

		    //4
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---30", score.LastFrame.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.LastFrame.ToString());
		    Assert.AreEqual("X---", score.ToString());
		
		    //5
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---60", score.LastFrame.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.LastFrame.ToString());
		    Assert.AreEqual("X---", score.ToString());
		
		    //6
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---90", score.LastFrame.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.ToString());
		
		    //7
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---120", score.LastFrame.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.ToString());
		
		    //8
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---150", score.LastFrame.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.ToString());
		
		    //9
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---180", score.LastFrame.LastFrame.LastFrame.ToString());
		    Assert.AreEqual("X---", score.ToString());
		
		    //10.1
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---", score.ToString());

		    //10.2
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X-X--", score.ToString());

		    //10.3
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---270", score.LastFrame.ToString()); //frame9
		    Assert.AreEqual("X-X-X-300", score.ToString());
		
	    }
	
	    [TestMethod]
	    public void testTenthFrameFrontSpareNumber_E() {
		    //Frame:	1	2	3	4	5	6	7	8	9	10
		    //Score:	30	60	90	120	150	180	210	235	255	270

		
		    Frame score = panel.addScore("Player1","X");
		    score = panel.addScore("Player1","X");//2
		    score = panel.addScore("Player1","X");//3
		    score = panel.addScore("Player1","X");//4
		    score = panel.addScore("Player1","X");//5
		    score = panel.addScore("Player1","X");//6
		    score = panel.addScore("Player1","X");//7
		    score = panel.addScore("Player1","X");//8
		    score = panel.addScore("Player1","X");//9
		
		    //10.1
		    score = panel.addScore("Player1","5");
		    Assert.AreEqual("5---", score.ToString());

		    //10.2
		    score = panel.addScore("Player1","/");
		    Assert.AreEqual("5-/--", score.ToString());

		    //10.3
		    score = panel.addScore("Player1","5");
		    Assert.AreEqual("X---255", score.LastFrame.ToString()); //frame9
		    Assert.AreEqual("5-/-5-270", score.ToString());
		
	    }
	
	    [TestMethod]
	    public void testTenthFrameFrontSpareStrike_F() {
		    //Frame:	1	2	3	4	5	6	7	8	9	10
		    //Score:	30	60	90	120	150	180	210	235	255	275

		
		    Frame score = panel.addScore("Player1","X");
		    score = panel.addScore("Player1","X");//2
		    score = panel.addScore("Player1","X");//3
		    score = panel.addScore("Player1","X");//4
		    score = panel.addScore("Player1","X");//5
		    score = panel.addScore("Player1","X");//6
		    score = panel.addScore("Player1","X");//7
		    score = panel.addScore("Player1","X");//8
		    score = panel.addScore("Player1","X");//9
		
		    //10.1
		    score = panel.addScore("Player1","5");
		    Assert.AreEqual("5---", score.ToString());

		    //10.2
		    score = panel.addScore("Player1","/");
		    Assert.AreEqual("5-/--", score.ToString());

		    //10.3
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---255", score.LastFrame.ToString()); //frame9
		    Assert.AreEqual("5-/-X-275", score.ToString());
		
	    }
	
	    [TestMethod]
	    public void testTenthFrameStrikeBackSpare_D() {
		    //Frame:	1	2	3	4	5	6	7	8	9	10
		    //Score:	30	60	90	120	150	180	210	240	265	285
		
		    Frame score = panel.addScore("Player1","X");
		    score = panel.addScore("Player1","X");//2
		    score = panel.addScore("Player1","X");//3
		    score = panel.addScore("Player1","X");//4
		    score = panel.addScore("Player1","X");//5
		    score = panel.addScore("Player1","X");//6
		    score = panel.addScore("Player1","X");//7
		    score = panel.addScore("Player1","X");//8
		    score = panel.addScore("Player1","X");//9
		
		    //10.1
		    score = panel.addScore("Player1","X");
		    Assert.AreEqual("X---", score.ToString());

		    //10.2
		    score = panel.addScore("Player1","5");
		    Assert.AreEqual("X-5--", score.ToString());

		    //10.3
		    score = panel.addScore("Player1","/");
		    Assert.AreEqual("X---265", score.LastFrame.ToString()); //frame9
		    Assert.AreEqual("X-5-/-285", score.ToString());
	    }
    }
}
