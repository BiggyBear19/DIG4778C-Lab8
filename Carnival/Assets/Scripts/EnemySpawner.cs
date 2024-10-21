using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject enemy2;

    [SerializeField] private float interval = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Its started");
        spawnTarget(enemy);
        StartCoroutine(spawnTarget())
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnTarget(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3(10,0,0);
        Instantiate(enemy, spawnPosition, quaternion.identity);
    }

    private IEnumerator spawnTarget()
    {
        while (true)
        {
            Debug.Log("Spawning enemy");
            spawnTarget(enemy);
            yield return new WaitForSeconds(interval);
        }
    }
}
