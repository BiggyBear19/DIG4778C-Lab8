using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<GameObject> objectPool = new List<GameObject>();
    public GameObject projectilePrefab;
    public Transform firingPoint;

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
        // Loop through the object pool to find the first inactive projectile
        foreach (GameObject projectile in objectPool)
        {
            if (!projectile.activeSelf) // If the projectile is inactive
            {
                projectile.transform.position = firingPoint.position;
                projectile.SetActive(true); // Activate it
                Debug.Log($"Activating {projectile.name}");
                StartCoroutine(waitForDeactivate(projectile));
                break; // Exit the loop after activating one projectile
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
