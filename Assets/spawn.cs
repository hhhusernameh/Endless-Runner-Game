using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // create a public arrey of objects to spawn, we'll fill this up using the unity editor
    public GameObject[] objectsToSpawn;

    float timeToNextSpawn;      // Tracks how long we should wait before spawning a new object
    float timeSinceLastSpawn = 0.0f;    //tracks the time since we last spawned something

    public float minSpawnTime = 0.5f;  // min amount of time between spawning objects
    public float maxSpawnTime = 3.0f;  // max amount of time between spawning objects


    // Start is called before the first frame update
    void Start()
    {
        // random range returns a random float between 2 values
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Add Time.deltaTime returns the amount of time passed since the last frame
        // this will create a float that counts up in seconds
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        //If we've counted past the amount of time we need to wait...
        if (timeSinceLastSpawn > timeToNextSpawn)
        {
            // use Random.Range to pick a number between 0 and the amount of items on our object list
            int selection = Random.Range(0, objectsToSpawn.Length);

            //Instantiate spawns a Gameobject - in this case we will tell it to spawn a GameObject from our ObjectsToSpawn list
            //The second parameter in the brackeyts tells it where to spawn, so we've entered the position of the spawner
            // the third parameter is for rotation, and quarternion.identity means no rotation
            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);
            // After spawning, we select a new random time for the next spawn and set our time back to 0
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
    }
}