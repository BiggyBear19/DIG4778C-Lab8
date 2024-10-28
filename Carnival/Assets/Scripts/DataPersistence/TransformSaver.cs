using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformSaver
{
    public Vector3 playerTransform;
    public int score;
    public List<Vector3> enemyTransform;

    //the values defined in this construtor will be the default values
    //When theres no data to load this is what will be loaded
    public TransformSaver()
    {
        playerTransform = Vector3.zero;
        score = 0;
        enemyTransform = new List<Vector3>();
    }
}
