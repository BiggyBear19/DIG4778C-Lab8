using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Projectile
{
    public static ObjectPool instance;

    public List<GameObject> objectPool = new List<GameObject>();
    public GameObject projectilePrefab;

    public Transform firingPoint;

    public float projectileSpeed = 15f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
                return;
        }
        else
        {
            instance = this;
        }
        PopulateProjectilePool();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
    }

    void PopulateProjectilePool()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            //probably add impulse here
            objectPool.Add(newProjectile);
            newProjectile.SetActive(false);
        }
    }

    public void ShootProjectile()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
              objectPool[i].SetActive(true);
              //rgbd.linearVelocity = transform.up * projectileSpeed ;
        }
    }

    public void DeactivateProjectile()
    {
        projectilePrefab.SetActive(false);
    }
}
