using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelingSystem : MonoBehaviour
{
    public StatsSystem myStatSystem; // a reference to our stats system
    public int currentLevel; // Current level.
    public int currentXp; // XP accumilated.
    public int currentXPThreshold = 10; // XP required to level up.

    /// <summary>
    /// sets our script to default values
    /// Step 01: called when you click on Test Level System
    /// Step 02: Called in start of the character class.
    /// Step 03: Called in start of the character class.
    /// </summary>
    //Set the players default values.
    public void SetDefaultValues()
    {
        currentLevel = 1;
        currentXp = 0;
        currentXPThreshold = currentLevel * 100; //XP threshold formula is the current level * 100.
    }

    /// <summary>
    /// A function called when the battle is completed and some xp is to be awarded.
    /// The amount of xp gained is coming into this function
    /// Step 01: called when you click on Test Level System
    /// Step 02: ideally called after we declar a winner of a fight, should probs give them some xp.
    /// Step 03: ideally called after we declar a winner of a fight, should probs give them some xp.
    /// </summary>
    //Add XP to the players current XP, and level them up if they are above their threshold.
    public void AddXP(int xpGained)
    {
        //Add gained XP to current XP.
        currentXp += xpGained;

        //Check if they have enough XP to level up, and add levels/remove Xp if they are.
        //This is in a while loop so if they have enough to level up multiple times, it will detect it.
        while (currentXp >= currentXPThreshold)
        {
            currentXp -= currentXPThreshold;
            LevelUp();
        }

    }

    /// <summary>
    /// A function used to handle actions associated with levelling up.
    /// Step 01: called when you click on Test Level System
    /// Step 02: Called when we add some xp.
    /// Step 03: Called when we add some xp.
    /// </summary>
    //Level up the player and recalculate XP.
    private void LevelUp()
    {
        //Increase the current level and reculauate the next XP theshold. 
        currentLevel += 1;
        currentXPThreshold = currentLevel * 100; 
    }

    #region No Mods Required.
    public void TestImplementation()
    {
        SetDefaultValues();
        Debug.Log(string.Format("Current Xp is {0} the current level is {1} and the current threshold is {2}", currentXp, currentLevel, currentXPThreshold));
        AddXP(200);
        Debug.Log(string.Format("Current Xp is {0} the current level is {1} and the current threshold is {2}", currentXp, currentLevel, currentXPThreshold));
        myStatSystem.TestDistributePhysicalStatsOnLevelUp(); // in theory if we've distributed our stats they should be different.
    }
    #endregion
}
