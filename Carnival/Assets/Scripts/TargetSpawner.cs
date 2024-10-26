using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class TargetSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Orc;
    public GameObject Skeleton;
    public GameObject Crab;

    private float spawn_timer = 2f;
    
    //this works i just need to add in the timer and set up precongfigured build options
    void Start()
    {

        TargetSpawnSkeleton();
       

    }
    

    // ReSharper disable Unity.PerformanceAnalysis
   
    private void Update()
    {
        // Spawn the enemies in waves
    }
    
    private void TargetSpawnSkeleton()
    {
        Target newTarget = new Target.TargetBuilder().withHP(2).withSpeed(2).withScore(3)
            .withGameObject(Skeleton).BuildOrc();
        Instantiate(newTarget, new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0f), Quaternion.identity);
    }
    
    private void TargetSpawnCrab()
    {
        Target newTarget = new Target.TargetBuilder().withHP(2).withSpeed(2).withScore(3)
            .withGameObject(Skeleton).BuildOrc();
        Instantiate(newTarget, new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0f), Quaternion.identity);
    }
    
    private void TargetSpawnOrc()
    {
        Target newTarget = new Target.TargetBuilder().withHP(2).withSpeed(2).withScore(3)
            .withGameObject(Skeleton).BuildOrc();
        Instantiate(newTarget, new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0f), Quaternion.identity);
    }
}

 