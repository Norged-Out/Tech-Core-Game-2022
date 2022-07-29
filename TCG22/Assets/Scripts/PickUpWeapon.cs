using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public bool held;
    public Transform firePoint;
    public GameObject bulletPrefab;


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

    public void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0,90));
    }
}
