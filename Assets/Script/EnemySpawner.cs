using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform player;

    public float spawnRate = 2f;
    public float minDistance = 10f;
    public float maxDistance = 20f;

    private float nextSpawn;
    // Update is called once per frame
    void Update()
    {
        if (player == null || enemyPrefab.Length == 0) return;
        if(Time.time >= nextSpawn){
            SpawnEnemy();
            nextSpawn = Time.time+spawnRate;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefab.Length);
        GameObject selectedEnemy = enemyPrefab[randomIndex];
        Vector2 randomSpawner = Random.insideUnitCircle.normalized;
        float randomDist = Random.Range(minDistance, maxDistance);
        Vector3 spawnPos = player.position + (Vector3)(randomSpawner * randomDist);
        if (selectedEnemy != null)
        {
			Instantiate(selectedEnemy, spawnPos, Quaternion.identity);
		}
    }
}
