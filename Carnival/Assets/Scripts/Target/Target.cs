using System;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health { get; private set; }
    public float speed { get; private set; }
    public int scoreValue { get; private set; }
    
    public GameObject TargetGameObject { get; private set; }
    

   //Target Behavior
   // Setting up the GameManager for saving and 
   void Start()
   {
       
   }

   void Update()
   {
       
   }

   private void OnTriggerEnter(Collider other)
   {
       if (other.tag == "Bullet")
       {
           damage(1);
       }
   }

   public void damage(int dmgNum)
   {
       health -= dmgNum;
       if (health < 0)
       {
           Destroy(gameObject);
           //notify the observer 
       }
   }

   //Builder Function Below
    
    public class TargetBuilder
    {
        int health;
        float speed;
        int scorevalue;
        private GameObject prefab;
        private Target _target = new Target();

        public TargetBuilder createTarget(string name)
        {
            _target.TargetGameObject = new GameObject(name);
            return this;
        }
        public TargetBuilder withHP(int health)
        {
            _target.health = health;
            return this;
        }

        public TargetBuilder withSpeed(float speed)
        {
            _target.speed = speed;
            return this;
        }

        public TargetBuilder withScore(int scoreValue)
        {
            _target.scoreValue = scorevalue;
            return this;
        }
        

        public TargetBuilder addSprite(Sprite sprite)
        {
            var sp = _target.TargetGameObject.AddComponent<SpriteRenderer>();
            sp.sprite = sprite;
            return this;
        }

        public TargetBuilder addRigidBody()
        {
            var rb = _target.TargetGameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            return this;
        }

        public Target Build()
        {
            return _target;
        }

        public Target BuildRed(Sprite sprite)
        {
            
            var red = new GameObject("RedTarget").AddComponent<Target>();
            red.AddComponent<Rigidbody2D>().gravityScale = 0f;
            red.health = 2;
            red.speed = 4;
            red.scoreValue = 3;
            red.AddComponent<SpriteRenderer>().sprite = sprite;
            red.AddComponent<BoxCollider2D>();
            return red;
        }
        
        public Target BuildBlue(Sprite sprite)
        {
            
            var blue = new GameObject("BlueTarget").AddComponent<Target>();
            blue.AddComponent<Rigidbody2D>().gravityScale = 0f;
            blue.health = 3;
            blue.speed = 2;
            blue.scoreValue = 2;
            blue.AddComponent<SpriteRenderer>().sprite = sprite;
            blue.AddComponent<BoxCollider2D>();
            return blue;
        }
        
        public Target BuildPurple(Sprite sprite)
        {
            
            var purple = new GameObject("PurpleTarget").AddComponent<Target>();
            purple.AddComponent<Rigidbody2D>().gravityScale = 0f;
            purple.health = 1;
            purple.speed = 4;
            purple.scoreValue = 1;
            purple.AddComponent<SpriteRenderer>().sprite = sprite;
            purple.AddComponent<BoxCollider2D>();
            return purple;
        }

    }
}
