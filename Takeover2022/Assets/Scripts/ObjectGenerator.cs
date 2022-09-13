using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject barrel;
    [SerializeField]
    private GameObject breakableDoor;

    [SerializeField]
    private List<GameObject> chunks;

    [SerializeField]
    private float spawnDistance;
    [SerializeField]
    private float spawnCooldown;
    [SerializeField]
    private float chunkSpawnCooldown;
    private bool firstSpawnCheck;
    [SerializeField]
    [Header("Out of 10")]
    private int chunkChance;

    [SerializeField]
    [Header("This should always be at least 5 less than the spawn cooldown.")]
    private float maxDifficultyModifier;
    [SerializeField]
    private float difficultyModifier;
    [SerializeField]
    private float difficultyIncreaseCooldown;
    private bool firstDifficultyCheck;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacle");
        StartCoroutine("IncreaseDifficulty");
    }

    //Spawn an obstacle.
    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            //Don't spawn an obstacle when starting.
            if (firstSpawnCheck)
            {

                //Check the difficulty modifier is less than or equal to the max. Any higher
                //and it risks impossible to avoid obstacles.
                if (difficultyModifier > maxDifficultyModifier)
                {
                    difficultyModifier = maxDifficultyModifier;
                }

                //Decide whether to spawn an obstacle or a chunk.
                int spawnChunk = Random.Range(0, 11);

                if (spawnChunk < chunkChance && chunks.Count > 0)
                {
                    //Decide which chunk to spawn.
                    int chunkNumber = Random.Range(0, 2);

                    //Figure out where to spawn the chunk.
                    Vector3 obstaclePosition = player.transform.position + player.transform.forward * spawnDistance;
                    obstaclePosition = new Vector3(obstaclePosition.x, 0, -8.5f);

                    //Spawn a random chunk.
                    Instantiate(chunks[Random.Range(0, chunks.Count)], obstaclePosition, Quaternion.identity);

                    //Set a timer to spawn another obstacle or chunk.
                    yield return new WaitForSeconds(chunkSpawnCooldown - difficultyModifier - Random.Range(1, 4));
                }

                else
                {
                    //Decide which obstacle to spawn.
                    int obstacleNumber = Random.Range(0, 2);

                    //Figure out where to spawn the obstacle.
                    Vector3 obstaclePosition = player.transform.position + player.transform.forward * spawnDistance;

                    //Spawn the obstacle

                    //Barrel
                    if (obstacleNumber == 0)
                    {
                        obstaclePosition = new Vector3(obstaclePosition.x, -3.2f, -8.5f);
                        Instantiate(barrel, obstaclePosition, Quaternion.identity);
                    }

                    //Metal Door
                    else
                    {
                        obstaclePosition = new Vector3(obstaclePosition.x, -3.2f, -8.5f);
                        Instantiate(breakableDoor, obstaclePosition, Quaternion.identity);
                    }

                    //Set a timer to spawn another obstacle or chunk.
                    yield return new WaitForSeconds(spawnCooldown - difficultyModifier - Random.Range(1, 4));
                }
            }

            else
            {
                firstSpawnCheck = true;
                yield return new WaitForSeconds(3);
            }
        }
    }

    //Increases the difficulty modifier.
    IEnumerator IncreaseDifficulty()
    {
        while (true)
        {
            //Don't increase difficulty when starting.
            if (firstDifficultyCheck)
            {
                if (difficultyModifier <= maxDifficultyModifier)
                {
                    difficultyModifier++;
                }

                yield return new WaitForSeconds(difficultyIncreaseCooldown);
            }

            else
            {
                firstDifficultyCheck = true;
                yield return new WaitForSeconds(difficultyIncreaseCooldown);
            }
        }
    }
}
