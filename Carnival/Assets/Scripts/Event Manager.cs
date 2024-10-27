using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    
    public event Action<int> OnEnemyKill;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public void EnemyKilled(int score)
    {
        OnEnemyKill?.Invoke(score);
    }
}
