using UnityEngine;

public class Target : MonoBehaviour
{
    public int health;

    public int scorevalue;

    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.MoveTowards(this.transform.position, player.transform.position, 10);
    }
}
