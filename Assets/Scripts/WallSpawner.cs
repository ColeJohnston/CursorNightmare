using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab; // Prefab for the wall to spawn

    public float distanceFromCeiling = .1f; // Distance from the ceiling to spawn walls (percentage of screen height)

    public float gapInWalls = .5f; // Gap between walls percentage of screen height
    public float gapBetweenWallsMin = 0.175f;

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
                gapInWalls -= Time.deltaTime * 0.025f; // Gradually decrease the gap between walls
            }

            if (spawnInterval > spawnIntervalMin)
            {
                spawnInterval -= Time.deltaTime * 0.025f; // Gradually decrease the spawn interval
                print(spawnInterval);
            }

            //if (TimeSinceLastSpawn >= spawnInterval)
            //{
            //    SpawnWall();
            //    TimeSinceLastSpawn = 0f; // Reset the timer after spawning a wall
            //}
            //else
            //{
            //    TimeSinceLastSpawn += Time.deltaTime; // Increment the timer
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, .5f, Camera.main.nearClipPlane));
        SpawnWall();
        print("spawning");
    }


    void SpawnWall()
    {
        float ySpawn = Random.Range(distanceFromCeiling + gapInWalls, 1 - (distanceFromCeiling + gapInWalls));

        float upperBound = ySpawn + .5f + (gapInWalls / 2);
        float lowerBound = ySpawn - .5f - (gapInWalls / 2);

        Instantiate(wallPrefab, new Vector3(transform.position.x, PercentToWorldSpace(upperBound), transform.position.z), Quaternion.identity);

        GameObject temp = Instantiate(wallPrefab, new Vector3(transform.position.x, PercentToWorldSpace(lowerBound), transform.position.z), Quaternion.identity);
        temp.GetComponent<SpriteRenderer>().color = Color.rebeccaPurple;


    }

    private float PercentToWorldSpace(float percentage)
        {
        return Camera.main.ViewportToWorldPoint(new Vector3(0, percentage, Camera.main.nearClipPlane)).y;
        }
}
