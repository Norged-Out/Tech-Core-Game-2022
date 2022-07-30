using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public bool held;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private GameObject cyborgArm;


    // Start is called before the first frame update
    void Start()
    {
        cyborgArm = this.transform.Find("Cyborg_Arm").gameObject;
        cyborgArm.GetComponent<SpriteRenderer>().enabled = false;
        cyborgArm.GetComponent<Animator>().enabled = false;

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
            
            cyborgArm.GetComponent<SpriteRenderer>().enabled = false;
            cyborgArm.GetComponent<Animator>().enabled = false;

        }
        if (held && this.transform.parent.name == "Player_Cyborg")
        {
            cyborgArm.GetComponent<SpriteRenderer>().enabled = true;
            cyborgArm.GetComponent<Animator>().enabled = true;
        }
    }

    public void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0,90));
    }
}
