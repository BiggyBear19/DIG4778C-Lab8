using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class TargetSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite Red;
    public Sprite Blue;
    public Sprite Purple;

    private float spawn_timer = 2f;
    
    //this works i just need to add in the timer and set up precongfigured build options
    void Start()
    {

        SpawnRed();
        SpawnBlue();
        SpawnPurple();
       

    }
    

    // ReSharper disable Unity.PerformanceAnalysis
   
    private void Update()
    {
        // Spawn the enemies in waves
    }
    
    private void SpawnRed()
    {
        Target newTarget = new Target.TargetBuilder().BuildRed(Red);
        Instantiate(newTarget, new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0f), Quaternion.identity);
    }
    
    private void SpawnBlue()
    {
        Target newTarget = new Target.TargetBuilder().BuildBlue(Blue);
        Instantiate(newTarget, new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0f), Quaternion.identity);
    }
    
    private void SpawnPurple()
    {
        Target newTarget = new Target.TargetBuilder().BuildPurple(Purple);
        Instantiate(newTarget, new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0f), Quaternion.identity);
    }
}

 