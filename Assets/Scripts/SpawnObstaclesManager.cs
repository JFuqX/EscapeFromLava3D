using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaclesManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private int levelLength = 200;
    private float spawnPositionZ = 20;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPositionZ <= levelLength)
        {
            SpawnObstacle();
        }
    }


    private void SpawnObstacle()
    {
        int rand = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[rand], new Vector3(0,1.5f,spawnPositionZ), obstacles[rand].transform.rotation);
        spawnPositionZ += 10;
    }
}
