using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<GameObject> objectPool = new List<GameObject>();
    public GameObject projectilePrefab;
    public Transform firingPoint;
    private float projectileSpeed = 8f;

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
            objectPool.Add(newProjectile);
            newProjectile.SetActive(false);
        }
    }

    public void ShootProjectile()
    {
        // Loop through the object pool to find the first inactive projectile
        foreach (GameObject projectile in objectPool)
        {
            if (!projectile.activeSelf) 
            {
                projectile.transform.position = firingPoint.position;
                projectile.SetActive(true); 
                Rigidbody2D rgbd = projectile.GetComponent<Rigidbody2D>();
                if (rgbd != null)
                {
                    rgbd.linearVelocity = projectile.transform.up * projectileSpeed;
                }
                Debug.Log($"Activating {projectile.name}");
                StartCoroutine(waitForDeactivate(projectile));
                break; 
            }
        }
    }

    IEnumerator waitForDeactivate(GameObject projectile)
    {
        yield return new WaitForSeconds(5f);
        if (projectile.activeSelf) projectile.SetActive(false);

        Debug.Log("Coroutining");
    }

    public void DeactivateProjectile()
    {
        projectilePrefab.SetActive(false);
        Debug.Log("Deactivating projectile");
    }
}
