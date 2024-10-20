using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Score;

    private void Awake()
    {
        instance = this;
        Score = 0;
    }

    public event Action OnTargetKill;
    public void TargetHit()
    {
        if (OnTargetKill != null)
        {
            OnTargetKill();
        }
    }
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
