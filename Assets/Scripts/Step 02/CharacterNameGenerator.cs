using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - Create Names
/// - Set Individual Name
/// - Set Team Character Names
/// </summary>
public class CharacterNameGenerator : MonoBehaviour
{
 
    [Header("Possible first names")]
    private List<string> firstNames = new List<string>(); // a list of all possible first names for us to use.
    [Header("Possible last names")]
    private List<string> lastNames = new List<string>(); // a list of all possible last names for us to use.
    [Header("Possible nicknames")]
    private List<string> nickNames = new List<string>(); // a list of all possible nick names for us to use.

    private void Awake()
    {
        //Generates the Names
        CreateNames();
    }

    /// <summary>
    /// Creates a list of names for all our characters to potentiall use.
    /// Step 02: Called when we press play.
    /// Step 03: Called when we press play.
    /// </summary>
    //Fills the firstNames, lastNames and nicknames lists with values.
    public void CreateNames()
    {
        // So here we would ideally want to be able to add some names to our first names, last names and nick names lists.
        firstNames.Add("Jesse");
        firstNames.Add("Walter");
        firstNames.Add("Gus");
        firstNames.Add("Saul");
        firstNames.Add("Mike");
        firstNames.Add("William");
        firstNames.Add("Freddy");
        firstNames.Add("Bonnie");
        firstNames.Add("Chica");

        lastNames.Add("Pinkman");
        lastNames.Add("White");
        lastNames.Add("Fring");
        lastNames.Add("Goodman");
        lastNames.Add("Ehrmantraut");
        lastNames.Add("Afton");
        lastNames.Add("Fazbear");
        lastNames.Add("Bunny");
        lastNames.Add("Chicken");

        nickNames.Add("The Student");
        nickNames.Add("The Cook");
        nickNames.Add("The Businessman");
        nickNames.Add("The Lawyer");
        nickNames.Add("The Cool Kid");
        nickNames.Add("The Immortal");
        nickNames.Add("The Performer");
        nickNames.Add("The Jumper");
        nickNames.Add("The Glutton");
    }

    /// <summary>
    /// set a characters name to a random name
    /// Step 02: Called when we press the test step 02 button and sets each dancer to have a name.
    /// </summary>
    /// <param name="character"></param>
    //Set the character to a randomly generated name based on the lists.
    public void SetIndividualCharacter(CharacterName character)
    {
        //Set first name, last name and nickname to a random value in the correspondong list, and set the relevent variable in the charactername script.
        character.firstName = firstNames[Random.Range(0, firstNames.Count)];
        character.lastName = lastNames[Random.Range(0, lastNames.Count)]; ;
        character.nickName = nickNames[Random.Range(0, nickNames.Count)];
    }

    /// <summary>
    /// Same as an individual...but this time it's more than one dancer.
    /// Step 03: Called from the Spawn function.
    /// </summary>
    /// <param name="namesNeeded"></param>
    /// <returns></returns>
    //Setup names for a list of objects (players).
    public void SetTeamCharacterNames(List<CharacterName> teamCharacters)
    {
        //Iterates though each value in the list and changes that names in that index. This system works regardless of the amount of values in the list.
        for (int i = 0; i < teamCharacters.Count; i++)
        {
            teamCharacters[i].firstName = firstNames[Random.Range(0, firstNames.Count)];
            teamCharacters[i].lastName = lastNames[Random.Range(0, lastNames.Count)];
            teamCharacters[i].nickName = nickNames[Random.Range(0, nickNames.Count)];
        }
    }
}