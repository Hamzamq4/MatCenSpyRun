using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGenerator : MonoBehaviour
{
    public Transform[] lanes; // the three lanes

    public float spacing = 5f;

    public GameObject coin;

    private float nextSpawn = 1f;

    private Transform player;

    public float spawnStartTime;

    private float elapsedSeconds; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedSeconds += Time.deltaTime;
        if (elapsedSeconds >= spawnStartTime)
        {
            if (Time.time > nextSpawn) 
            {
                int laneIndex = Random.Range(0, 3);
                Instantiate(coin, lanes[laneIndex].position + new Vector3(-1.6f, 5.5f, player.position.z + 60f), Quaternion.identity);

                nextSpawn = Time.time + spacing;
            }
        }
    }
}
