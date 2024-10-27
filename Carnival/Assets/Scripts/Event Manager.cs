using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

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

    public event Action<int> OnEnemyKill;

    public void EnemyKilled(int score)
    {
        OnEnemyKill?.Invoke(score);
    }
}
