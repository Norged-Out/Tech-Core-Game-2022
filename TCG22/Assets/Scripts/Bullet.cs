using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rbBullet;
    public GameObject Explosion;
    void Start()
    {
        
        if (GameObject.Find("Player_Cyborg") != null && Vector2.Distance(GameObject.Find("Player_Cyborg").transform.position, transform.position) < 1) {
            if (GameObject.Find("Player_Cyborg").transform.parent.GetComponent<PlayerController>().FacingRight) {
                rbBullet.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
            else {
                rbBullet.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        }
        else if (GameObject.Find("Player_Punk") != null && Vector2.Distance(GameObject.Find("Player_Punk").transform.position, transform.position) < 1)
        {
            if (GameObject.Find("Player_Punk").transform.parent.GetComponent<PlayerController>().FacingRight) {
                rbBullet.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
            else {
                rbBullet.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        } else if (GameObject.Find("Player_Biker") != null && Vector2.Distance(GameObject.Find("Player_Biker").transform.position, transform.position) < 1) 
        {
            if (GameObject.Find("Player_Biker").transform.parent.GetComponent<PlayerController>().FacingRight) {
                rbBullet.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
            else {
                rbBullet.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        }
        else{
            Debug.Log("RIP");
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo){
        if(!hitInfo.CompareTag("Player") &&!hitInfo.CompareTag("Projectile") && !hitInfo.CompareTag("Weapon 1") && !hitInfo.CompareTag("Weapon 2") && !hitInfo.CompareTag("Weapon 3") && !hitInfo.CompareTag("Weapon 4") && !hitInfo.CompareTag("Weapon 5") && !hitInfo.CompareTag("Weapon 6") && !hitInfo.CompareTag("Weapon 7") && !hitInfo.CompareTag("Weapon 8") && !hitInfo.CompareTag("Weapon 9") && !hitInfo.CompareTag("Weapon 10")){
            Debug.Log(hitInfo.name);
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}