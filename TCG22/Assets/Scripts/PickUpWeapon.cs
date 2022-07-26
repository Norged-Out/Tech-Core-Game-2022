using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public bool held;

    // Start is called before the first frame update
    void Start()
    {
        held = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && held)
        {
            this.transform.parent = null;
            this.transform.position += Vector3.left;
            held = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Lets Player Pick Up Weapon
        if (collision.CompareTag("Player") && collision.gameObject.transform.childCount == 0)
        {
            this.transform.parent = collision.transform;
            this.transform.position = collision.gameObject.transform.position;
            held = true;
        }
    }
}
