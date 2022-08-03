using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rbBullet;
    public GameObject Explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        float distance = Vector2.Distance(GameObject.Find("Player_Punk").transform.position, transform.position);
        //float distance2 = Vector2.Distance(GameObject.Find("Player_Cyborg").transform.position, transform.position);
        
        if(distance < 0){
            if(GameObject.Find("Player_Cyborg").GetComponent<PlayerController>().FacingRight){
                rbBullet.AddForce(Vector2.right * speed,ForceMode2D.Impulse);
            }
            else{
                rbBullet.AddForce(Vector2.left * speed,ForceMode2D.Impulse);
            }
        }
        else{
            if(GameObject.Find("Player_Punk").GetComponent<PlayerController>().FacingRight){
                rbBullet.AddForce(Vector2.right * speed,ForceMode2D.Impulse);
            }
            else{
                rbBullet.AddForce(Vector2.left * speed,ForceMode2D.Impulse);
            }
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