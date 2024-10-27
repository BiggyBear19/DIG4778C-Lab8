using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = System.Object;

public class Target : MonoBehaviour
{
    public int health { get; private set; }
    public float speed { get; private set; }
    public int scoreValue { get; private set; }
    
    public GameObject TargetGameObject { get; private set; }
    private Transform player;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    int currentHealth;

   //Target Behavior
   // Setting up the GameManager for saving and 
   void Start()
   {
       currentHealth = health;
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = gameObject.GetComponent<Rigidbody2D>();

   }

   void Update()
   {
       if (player)
       {
           Vector3 direction = (player.position - transform.position).normalized;
           moveDirection = direction;
       }
   }

   private void FixedUpdate()
   {
       if (player)
       {
           rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
       }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Bullet"))
       {
           damage(1);
       }
   }

   public void damage(int dmgNum)
   {
       currentHealth -= dmgNum;
       if (currentHealth <= 0)
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
