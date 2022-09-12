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
    private float spawnDistance;
    [SerializeField]
    private float spawnCooldown;

    [SerializeField]
    [Header("This should always be at least 5 less than the spawn cooldown.")]
    private float maxDifficultyModifier;
    [SerializeField]
    private float difficultyModifier;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacle");
    }

    //Spawn an obstacle.
    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            //Check the difficulty modifier is less than or equal to the max. Any higher
            //and it risks impossible to avoid obstacles.
            if (difficultyModifier > maxDifficultyModifier)
            {
                difficultyModifier = maxDifficultyModifier;
            }

            //Figure out where to spawn the obstacle.
            Vector3 obstaclePosition = player.transform.position + player.transform.forward * spawnDistance;
            obstaclePosition = new Vector3(obstaclePosition.x, 1.38f, -8.5f);

            //Spawn the obstacle.
            Instantiate(barrel, obstaclePosition, Quaternion.identity);

            //Set a timer to spawn another obstacle.
            yield return new WaitForSeconds(spawnCooldown - difficultyModifier - Random.Range(1, 4));
        }
    }
}
