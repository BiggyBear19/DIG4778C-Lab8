using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;


/*
public class Old: MonoBehaviour //Subject
{
    public int Health { get; private set; }
    public float Speed { get; private set; }
    
    public int ScoreValue { get; private set; }

    public Target(int health)
    {
        Health = health;
    }

    public Target(int health, float speed) : this(health)
    {
        Speed = speed;
    }

    public Target(int health, float speed, int scoreValue) : this(health, speed)
    {
        ScoreValue = scoreValue;
    }

    void Start()
    {
       // NotifyObservers(ScoreValue);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            this.Health -= 1;
            
        }
    }


    private void OnDeath()
    {
        Destroy(this.gameObject);
        
    }
    

    //Standardized EnemyBehavior goes here
    void Update()
    {
        if (Health == 0)
        {
            OnDeath();
        }
    }
    
    
    
    public class TargetBuilder : MonoBehaviour
    {
        public int health;
        public float speed;
        public int points;
        // add scorevalue

        public TargetBuilder theHealth(int health)
        {
            this.health = health;
            return this;
        }
    
        public TargetBuilder theSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public TargetBuilder theScore(int scorevalue)
        {
            this.points = scorevalue;
            return this;
        }
        
        //overload the build or premake 2 enemy types with a build function
        public Target Build()
        {
            var target = new GameObject("Target").AddComponent<Target>();
            target.Health = health;
            target.Speed = speed;
            target.ScoreValue = points;
            return target;
        }

        public Target BuildCrab()
        {
            var target = new GameObject("Target").AddComponent<Target>();
            target.Health = 1;
            target.Speed = 3f;
            target.ScoreValue = 1;
            return target;
            
            
        }
    
        public Target BuildOrc()
        {
            var target = new GameObject("Target").AddComponent<Target>();
            target.Health = 2;
            target.Speed = 2f;
            target.ScoreValue = 3;
            return target;
            
            
        }
        
        public Target BuildSkeleton()
        {
            var target = new GameObject("Target").AddComponent<Target>();
            target.Health = 1;
            target.Speed = 3f;
            target.ScoreValue = 2;
            return target;
            
            
        }
    }       
}

*/
