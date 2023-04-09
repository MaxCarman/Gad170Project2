using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - ReturnMyDancePowerLevel
/// - ReturnChanceToWin
/// </summary>
public class PowerLevel : MonoBehaviour
{
    public StatsSystem myStats; // a reference to our stats system

    /// <summary>
    /// Used to generate a number of battle points that is used in combat.
    /// Step 01: called when you click on Test Power System
    /// Step 02: called from our fight manager when we are fighting.
    /// Step 03: called from our fight manager when we are fighting.
    /// </summary>
    /// <returns></returns>
    //Generate power level by combining dance stats with some random variation.
    public int ReturnMyDancePowerLevel()
    {
        //Retrieve dance stats from stats script.
        int myLuck = myStats.luck;
        int myStyle = myStats.style;
        int myRhthm = myStats.rhythm;

        //Generate and return the power level by combining dance stats with a random multiplier for each.
        int myPowerLevel = (int)Mathf.Round(myLuck*Random.Range(0.8f, 1.2f) + myStyle*Random.Range(0.8f, 1.2f) + myRhthm*Random.Range(0.8f,1.2f));
        return myPowerLevel;
    }

    /// <summary>
    /// Returns the chance to win a fight given the two powerlevels 
    /// Step 01: called when you click on Test Power System
    /// Step 02: should be called from our fight manager when we are fighting.
    /// Step 03: should be called from our fight manager when we are fighting.
    /// </summary>
    /// <param name="myPowerLevel"></param>
    /// <param name="opponentPowerLevel"></param>
    /// <returns></returns>
    //Determine the chance for the player to win against another player.
    public float ReturnChanceToWin(int myPowerLevel,int opponentPowerLevel)
    {
        //Get faction of both and then multiply to find the % of the player winning.
        float chanceToWin = ((float)myPowerLevel / (myPowerLevel + opponentPowerLevel)) * 100;
        return chanceToWin; 
    }

    #region NoModificationsRequired
    public void TestImplementation()
    {
        int opponentPower = Random.Range(0, 20);
        int myPowerLevel = ReturnMyDancePowerLevel();
          
        float myChanceToWin = ReturnChanceToWin(myPowerLevel, opponentPower);
        float myOpponentChanceToWin = ReturnChanceToWin(opponentPower, myPowerLevel);

        Debug.Log(string.Format("My power is {0}, my opponents powerlevel is {1}, my chance to win is {2}% and my opponents is {3}%", myPowerLevel, opponentPower, myChanceToWin, myOpponentChanceToWin));
    }
    #endregion
}
