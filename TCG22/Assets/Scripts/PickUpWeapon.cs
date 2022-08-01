using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public bool held;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private GameObject arm;


    // Start is called before the first frame update
    void Start()
    {
        held = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (held)
        {
            if (this.transform.parent.name == "Player_Cyborg")
            {
                arm = this.transform.Find("Cyborg_Arm").gameObject;
            }
            else if (this.transform.parent.name == "Player_Punk")
            {
                arm = this.transform.Find("Punk_Arm").gameObject;
            }
            arm.GetComponent<SpriteRenderer>().enabled = true;
            arm.GetComponent<Animator>().enabled = true;
        }

        if (Input.GetKey(KeyCode.F) && held)
        {
            Debug.Log("1");
            this.transform.parent = null;
            this.transform.position += Vector3.left;
            held = false;
            
            arm.GetComponent<SpriteRenderer>().enabled = false;
            arm.GetComponent<Animator>().enabled = false;

        }
    }

    public void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0,90));
    }
}
