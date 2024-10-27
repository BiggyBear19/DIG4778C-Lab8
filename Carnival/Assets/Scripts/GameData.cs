using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int deathCount;

    //the values defined in this construtor will be the default values
    //When theres no data to load this is what will be loaded
    public GameData()
    {
        this.deathCount = 0;
    }
}
