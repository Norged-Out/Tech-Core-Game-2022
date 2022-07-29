using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.00000000000000000000001f;
    public Rigidbody2D rbBullet;
    public GameObject Explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Player Test").GetComponent<PlayerController>().FacingRight){
            rbBullet.AddForce(Vector2.right,ForceMode2D.Impulse);
        }
        else{
            rbBullet.AddForce(Vector2.left,ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        if(!hitInfo.CompareTag("Player") && !hitInfo.CompareTag("Weapon")){
            Debug.Log(hitInfo.name);
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}