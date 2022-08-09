using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public bool held = false;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject arm;
   
    void Update()
    {
        if (held)
        {
            Debug.Log(this.transform.parent.Find("Player_Cyborg") != null);
            Debug.Log(this.transform.parent.Find("Player_Punk") != null);
            Debug.Log(this.transform.parent.Find("Player_Biker") != null);
            if (this.transform.parent.Find("Player_Cyborg") !=  null)
            {
                arm = this.transform.Find("Cyborg_Arm").gameObject;
            }
            else if (this.transform.parent.Find("Player_Punk") != null)
            {
                arm = this.transform.Find("Punk_Arm").gameObject;
            }
            else if (this.transform.parent.Find("Player_Biker") != null)
            {
                arm = this.transform.Find("Biker_Arm").gameObject;
            }
            arm.GetComponent<SpriteRenderer>().enabled = true;
            arm.GetComponent<Animator>().enabled = true;

            if (Input.GetKey(KeyCode.F))
            {
            arm.GetComponent<SpriteRenderer>().enabled = false;
            arm.GetComponent<Animator>().enabled = false;
            this.transform.parent = null;
            this.transform.position += Vector3.left;
            held = false;
            Debug.Log("Dropping");
            }
        }
    }

    public void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0,0));
    }
}
