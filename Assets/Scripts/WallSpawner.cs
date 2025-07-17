using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab; // Prefab for the wall to spawn

    public float distanceFromCeiling = .1f; // Distance from the ceiling to spawn walls (percentage of screen height)

    public float gapInWalls = .25f; // Gap between walls percentage of screen height
    public float gapBetweenWallsMin = 0.05f;

    public float spawnInterval = 2f; // Time interval between wall spawns
    public float spawnIntervalMin = 0.5f; // Minimum time interval between wall spawns

    public float TimeSinceLastSpawn = 0f; // Timer to track when to spawn the next wall


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Place wall spawner at the right edge of the screen relative to the camera
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, .5f, Camera.main.nearClipPlane));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentGameState == GameManager.GameState.Playing)
        {
            if (gapInWalls > gapBetweenWallsMin)
            {
                gapInWalls *= .99f;
            }

            if (spawnInterval > spawnIntervalMin)
            {
                spawnInterval *= .99f;
            }

            if( TimeSinceLastSpawn >= spawnInterval)
            {
                SpawnWall();
                TimeSinceLastSpawn = 0f; // Reset the timer after spawning a wall
            }
            else
            {
                TimeSinceLastSpawn += Time.deltaTime; // Increment the timer
            }
        }
    }


    void SpawnWall()
    {
        float ySpawn = Random.Range(0 + distanceFromCeiling, 1 - distanceFromCeiling);

        Vector3 topWallSpawnPosition = new Vector3(transform.position.x, ySpawn + (gapInWalls / 2f), transform.position.z);
        Instantiate(wallPrefab, topWallSpawnPosition, Quaternion.identity);

        Vector3 bottomWallSpawnPosition = new Vector3(transform.position.x, ySpawn - (gapInWalls / 2f), transform.position.z);
        Instantiate(wallPrefab, bottomWallSpawnPosition, Quaternion.identity);


    }
}
