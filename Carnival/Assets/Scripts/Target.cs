using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class Target: MonoBehaviour
{
    public int Health { get; private set; }
    public float Speed { get; private set; }
    public Vector2 Startpoint { get; private set; }
    public Vector2 Endpoint { get; private set; }
    
    public int ScoreValue { get; private set; }

    public Target(int health)
    {
        Health = health;
    }

    public Target(int health, float speed) : this(health)
    {
        Speed = speed;
    }
    
    public Target(int health, float speed, Vector2 startpoint) : this(health, speed)
    {
        Startpoint = startpoint;
    }
    
    public Target(int health, float speed, Vector2 startpoint, Vector2 endpoint) : this(health, speed, startpoint)
    {
        Endpoint = endpoint;
    }

    public Target(int health, float speed, Vector2 startpoint, Vector2 endpoint, int scoreValue) : this(health, speed,
        startpoint, endpoint)
    {
        ScoreValue = scoreValue;
    }
    
    //Standardized EnemyBehavior goes here
    void Update()
    {
        //Movement
    }
    
    
    
    public class TargetBuilder : MonoBehaviour
    {
        public int health;
        public float speed;
        public Vector2 start;
        public Vector2 end;
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
    
        public TargetBuilder theStart(Vector2 start)
        {
            this.start = start;
            return this;
        }
    
        public TargetBuilder theEnd(Vector2 end)
        {
            this.end = end;
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
            target.Startpoint = start;
            target.Endpoint = end;
            target.ScoreValue = points;
            return target;
        }

        public Target BuildRed()
        {
            var target = new GameObject("Target").AddComponent<Target>();
            target.Health = 1;
            target.Speed = 2f;
            target.Startpoint = start;
            target.Endpoint = end;
            target.ScoreValue = 3;
            return target;
        }
    
    
    }       
}


