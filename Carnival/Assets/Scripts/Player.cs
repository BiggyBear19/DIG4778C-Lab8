using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private float speedx;
    

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedx = Input.GetAxisRaw("Horizontal") * speed;
        rb.linearVelocityX = speedx;
        
    }

    //shooting
    void shoot()
    {
        
    }
    
}
