using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour, IObserver
{
   [SerializeField] private Subject target;
   public Text scoreText;
   public int score = 0;

   private void Awake()
   {
      
   }

   private void Start()
   {
      //scoreText.text = score.ToString() + " :Points";
   }

   private void AddScore()
   {
      
   }

   private void OnEnable()
   {
      target.AddObserver(this);
   }

   private void OnDisable()
   {
      target.RemoveObserver(this);
   }

   public void Notify()
   {
      Debug.Log("The observer is notified");
   }
}
