using System;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health { get; private set; }
    public float speed { get; private set; }
    public int scoreValue { get; private set; }
    public GameObject prefab { get; private set; }

   //Target Behavior
   // Setting up the GameManager for saving and 
   void Start()
   {
       
   }

   void Update()
   {
       
   }


   //Builder Function Below
    
    public class TargetBuilder
    {
        int health;
        float speed;
        int scorevalue;
        GameObject prefab;


        public TargetBuilder withHP(int health)
        {
            this.health = health;
            return this;
        }

        public TargetBuilder withSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public TargetBuilder withScore(int scoreValue)
        {
            this.scorevalue = scorevalue;
            return this;
        }

        public TargetBuilder withGameObject(GameObject prefab)
        {
            this.prefab = prefab;
            return this;
        }

        public Target Build()
        {
            var target = new GameObject("Target").AddComponent<Target>();
            target.health = health;
            target.speed = speed;
            target.scoreValue = scorevalue;
            target.prefab = prefab;
            return target;
        }

        public Target BuildOrc()
        {
            var Orc = new GameObject("Target").AddComponent<Target>();
            Orc.AddComponent<Rigidbody2D>().gravityScale.Equals(0);
            Orc.AddComponent<SpriteRenderer>();
            Orc.health = 2;
            Orc.speed = 4;
            Orc.scoreValue = 2;
            Orc.prefab = prefab;
            return Orc;
        }

    }
}
