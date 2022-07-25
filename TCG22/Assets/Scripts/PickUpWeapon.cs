using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // Lets Player Pick Up Weapon
        if (other.CompareTag("Player"))
        {
            // Give Weapon To Player Controller <-------
            this.transform.parent = other.transform;
        }

        // Lets Player Drop Weapon
        if (other.CompareTag("Player"))
        {
            // Take Weapon From Player Controller <------
            this.transform.parent = null;
        }
    }
}
