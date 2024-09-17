using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // create a public reference to the player - we will assign this in the unity editor
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // change our position relative to the player's position
        transform.position = new Vector3(player.transform.position.x + 5, transform.position.y, transform.position.z);
    }
}