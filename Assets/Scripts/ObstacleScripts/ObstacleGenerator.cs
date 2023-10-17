using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for the obstacle generation, that handles normal obstacles and sound obstacles.
/// </summary>

public class ObstacleGenerator : MonoBehaviour 
{
    public Transform[] lanes; // the three lanes
    public float spacing = 5f; // space in units between obstacle generations

    public GameObject[] obstacles;
    public GameObject[] soundObstacles;// array of sounds obstacles
    public float soundObstacleSpacing = 20f; // space between sound obstacle generations

    private float nextSpawn = 1f; // time in units until next obstacle generation
    private int obstacleType = 0; // 0 for normal obstacles, 1 for sound obstacle

    private int currentTerrainLayer; //layer of currently active terrain
    private Transform player; // the player object

    public float spawnStartTime;
    private float elapsedSeconds;

    void Start() 
    {
        // finds the player object in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () 
    {
        //Start a timer and determines which types of obstacle should be instantiated based on a percentage given in the Random.value variable.
        elapsedSeconds += Time.deltaTime;
        if (elapsedSeconds >= spawnStartTime)
        {
            if (Time.time > nextSpawn) 
                {
                    int laneIndex = Random.Range(0, 3);
                    bool isSoundObstacle = Random.value < 0.3f;

                    if (isSoundObstacle) 
                    {
                        obstacleType = 1;
                        nextSpawn = Time.time + soundObstacleSpacing;
                    }
                else
                {
                    obstacleType = 0;
                }
                    

                    
                    // determines which obstacles to spawn
                    bool spawnOtherLanes = false; // flag to determine if obstacle should be spawned in other lanes

                    GameObject obstacleToSpawn;
                    if (obstacleType == 0) 
                    { // normal obstacle
                        obstacleToSpawn = obstacles[Random.Range(0, obstacles.Length)];
                        spawnOtherLanes = Random.value < 0.1f;
                    } 
                    else  
                    { // sound obstacle
                        obstacleToSpawn = soundObstacles[Random.Range(0, soundObstacles.Length)];
                    } 
                    // spawns the obstacles
                    Instantiate(obstacleToSpawn, lanes[laneIndex].position + new Vector3(-1.6f, 3.9f, player.position.z + 60f), Quaternion.identity);

                    GameObject otherObstacleToSpawn = null;
                    GameObject thirdObstacleToSpawn = null;


                    // Determines the object to be instantiated in one or potentially two other lanes and generates them accordingly
                    if (spawnOtherLanes) 
                    {
                        Debug.Log("Double forhindring!");
                        List<Transform> availableLanes = new List<Transform>(lanes);
                        availableLanes.RemoveAt(laneIndex);
                        int otherLaneIndex = Random.Range(0, availableLanes.Count);
                        Transform otherLane = availableLanes[otherLaneIndex];
                        availableLanes.RemoveAt(otherLaneIndex);

                        
                        thirdObstacleToSpawn = obstacles[Random.Range(0, obstacles.Length)];
                        otherObstacleToSpawn = obstacles[Random.Range(0, obstacles.Length)];
                        
                        
                        Instantiate(thirdObstacleToSpawn, availableLanes[0].position + new Vector3(-1.6f, 4.181f, player.position.z + 60f), Quaternion.identity);
                        Instantiate(otherObstacleToSpawn, otherLane.position + new Vector3(-1.6f, 4.181f, player.position.z + 60f), Quaternion.identity);
                        spawnOtherLanes = false;
                    }
                }   
        }
    }
}  