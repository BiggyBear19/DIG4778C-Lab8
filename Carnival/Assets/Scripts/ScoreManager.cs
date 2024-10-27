using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int total = 0;

    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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

    private void OnEnable()
    {
        if (!instance)
        {
            Debug.Log("Instance of eventmanager isnt initialized");
        }
        else
        {
            EventManager.instance.OnEnemyKill += UpTheScore;
        }
        
    }

    private void OnDisable()
    {
        EventManager.instance.OnEnemyKill -= UpTheScore;
    }

    void UpTheScore(int score)
    {
        total += score;
        UpdateUI();
    }

    private void UpdateUI()
    {
        Debug.Log("Updating the UI " + total);
        scoreText.text = "Score: " + total;
    }
}
