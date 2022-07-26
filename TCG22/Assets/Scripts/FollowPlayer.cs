using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script in order to allow the camera to follow the player as the player moves.
 * Modify the offset vector to control the camera's distance from the player.
 * You must apply this script to the camera object, and specify the player 
 * object in the inspector.
 * 
 * Author: Jamie Taube
 */

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0.05f, 0.05f, -10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
