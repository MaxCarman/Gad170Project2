using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSystem : MonoBehaviour
{
    public float playerHealth = 0;

    //Create Physical Stats
    public int agility = 0;
    public int intelligence = 0;
    public int strength = 0;

    //Create Dance Stats
    public int style = 0;
    public int luck = 0;
    public int rhythm = 0;

    private Character character;


    /// <summary>
    /// This function should set our starting stats of Agility, Strength and Intelligence
    /// to some default RANDOM values.
    /// Step 01: Called when you press initialise stat system 
    /// Step 02: Called in the Start() of Characters.cs
    /// Step 03: Called in the Start() of Characters.cs
    /// </summary>
    //Generate new random physical stats.
    public void GeneratePhysicalStatsStats()
    {
        //Set physical stats to random values
        agility = Random.Range(5,11);
        intelligence = Random.Range(5, 11);
        strength = Random.Range(5, 11);
    }

    /// <summary>
    /// This function should set our style, luck and ryhtmn to values
    /// based on our currrent agility,intelligence and strength.
    /// Step 01: Called when you press initialise stat system 
    /// Step 02: Called in the Start() of Characters.cs
    /// Step 03: Called in the Start() of Characters.cs
    /// </summary>
    //Determine the dancing stats of the character using specific multipliers and physical stats.
    public void CalculateDancingStats()
    {
        //Determine multipliers (Agility * 0.5 -> Rhythm) (Strength * 1 -> Style) (Intelligence * 1.5 -> Luck)
        float agilityMultiplier = 0.5f;
        float strengthMultiplier = 1f;
        float intelligenceMultiplier = 1.5f;

        //Send multipliers to debug log.
        Debug.Log("agilMulti = " + agilityMultiplier + " strMulti = " + strengthMultiplier + " intelMulti = " + intelligenceMultiplier);

        //Apply multipliers to create dance stats.
        style = (int)Mathf.Round(strength * strengthMultiplier);
        luck = (int)Mathf.Round(intelligence * intelligenceMultiplier);
        rhythm = (int)Mathf.Round(agility * agilityMultiplier);
    }

    /// <summary>
    /// We probably want to use this to remove some hp (mojo) from our character.....
    /// Then we probably want to check to see if they are dead or not from that damage and return true or false.
    /// Step 02: Should be called after we declare a winner in our fightmanager
    /// Step 03: Should be called after we declare a winner in our fightmanager
    /// </summary>
    //Change health, and destroy the player if their health is below 0. The incoming value will be negitive for damage, positive for healing.
    public void ChangeHealth(float amount)
    {
        //Apply damage to health.
        playerHealth -= amount;

        //Destroy the player if their health is 0 or less.
        if(playerHealth <= 0)
        {
            if (character != null) //Check if the character exist first to prevent errors.
            {
                character.RemoveFromTeam();
            }
        }
    }

    /// <summary>
    /// A function used to assign a random amount of points ot each of our skills.
    /// Step 01: Called when you test the level system
    /// Step 02: Should be called when we level our character up
    /// Step 03: Should be called when we level our character up
    /// </summary>
    //Distribute points rewarded evenly between stats and recalculate dance stats.
    public void DistributePhysicalStatsOnLevelUp(int PointsPool)
    {
        //Divide provided points evenly between each physical stat.
        agility += (int)Mathf.Round(PointsPool / 3.33f);
        intelligence += (int)Mathf.Round(PointsPool / 3.33f);
        strength += (int)Mathf.Round(PointsPool / 3.33f);
        //Recalculate dance stats based of the new physical stats.
        CalculateDancingStats();
    }

    #region No Mods Required
    //Step 02: Called in the Start() of Characters.cs
    //Step 03: Called in the Start() of Characters.cs
    public void SetDefaultValues()
    {
        playerHealth = 1f;
        GeneratePhysicalStatsStats();
        CalculateDancingStats();
        character = GetComponent<Character>();
    }

    public void TestImplementation()
    {
        GeneratePhysicalStatsStats();
        CalculateDancingStats();
        ChangeHealth(-0.6f);
        Debug.Log("Current health is: " + playerHealth);
        DistributePhysicalStatsOnLevelUp(10);
        TestDistributePhysicalStatsOnLevelUp();
    }

    public void TestDistributePhysicalStatsOnLevelUp()
    {
        Debug.Log(string.Format("The new physical stats are str {0}, agil {1}, int {2}, the dancing stats are style {3}, luck {4}, rhythm {5}",strength,agility,intelligence,style,luck,rhythm)); 
    }
    #endregion
}
