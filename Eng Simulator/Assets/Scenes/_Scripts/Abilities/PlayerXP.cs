using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    private static int experience = 0; // player always starts with 0 experience

    public int Experience
    { // Experience property exposes private field for usage by other scripts
        get
        {
            return experience;
        }
        set
        {
            experience += value;
        }
    }

    public int Level
    {
        get
        {
            return (int)Mathf.Floor(experience / 1000);
        }
        set
        {
            experience = value * 1000;
        }
    }
}
