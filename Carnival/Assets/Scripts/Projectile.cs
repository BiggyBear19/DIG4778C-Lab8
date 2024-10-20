using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ObjectPool objectPoolScript;
    public Rigidbody2D rgbd;
    public Transform firingPoint;
    private float projectileSpeed = 15f;

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

    public void applyVelocity()
    {
        this.transform.position = firingPoint.position; // Set it at the firing point
        GetComponent<Rigidbody>().linearVelocity = firingPoint.up * projectileSpeed; // Set velocity
    }

    IEnumerator deactivateTimer()
    {
        new WaitForSeconds(4f);
    }
}
