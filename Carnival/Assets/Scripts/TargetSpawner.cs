using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class TargetSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] bases;

    private float spawn_timer = 2f;
    
    void Start()
    {

        //Target.TargetBuilder target = new Target.TargetBuilder().withHP(3).withScore(2).withSpeed(1).withGameObject()
           // .Build();
       //Instantiate(target);
       

    }
    

    // ReSharper disable Unity.PerformanceAnalysis
   
    private void Update()
    {
        throw new NotImplementedException();
    }
    
    private void TargetSpawn()
    {
        int randomTarget = UnityEngine.Random.Range(0, bases.Length);
        Target newTarget = new Target.TargetBuilder().withHP(2).withSpeed(2).withScore(3)
            .withGameObject(bases[randomTarget]).Build();
        Instantiate(newTarget, new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0f), Quaternion.identity);
    }
}

 