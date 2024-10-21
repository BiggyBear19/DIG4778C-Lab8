using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject enemy2;

    [SerializeField] private float interval = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnTarget(interval, enemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnTarget(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, -6f), 0),
            Quaternion.identity);
        StartCoroutine(spawnTarget(interval, enemy));
    }
}
