using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private FileDataHandler fileDataHandler;

    private int total = 0;
    public TMP_Text scoreText;
    
    void Start()
    {
        
        string dataDirPath = Application.persistentDataPath; 
        string dataFileName = "score.dat";
        fileDataHandler = new FileDataHandler(dataDirPath, dataFileName);
        
        LoadScore();
    }
    
  
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
        if (!EventManager.instance)
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
        if (!EventManager.instance)
        {
            Debug.Log("Instance of eventmanager isnt initialized");
        }
        else
        {
            EventManager.instance.OnEnemyKill -= UpTheScore;
        }
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
    

    

    public void LoadScore()
    {
        
        total = fileDataHandler.LoadScore();
        UpdateUI(); // Update the UI with the loaded score
    }

    public void SaveScore()
    {
        
        fileDataHandler.SaveScore(total);
    }
}
