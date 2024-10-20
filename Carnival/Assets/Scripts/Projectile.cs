using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ObjectPool objectPoolScript;
    public Rigidbody2D rgbd;

    private void Start()
    {
        objectPoolScript = FindFirstObjectByType<ObjectPool>();
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Untagged"))
        {
            objectPoolScript.DeactivateProjectile();
        }
    }
}
