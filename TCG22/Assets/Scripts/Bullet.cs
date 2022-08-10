using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rbBullet;
    public GameObject Explosion;
    public string shotBy;

    void Start()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane + 1;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (GameObject.Find("Player_Cyborg") != null && GameObject.Find("Player_Cyborg").transform.parent.GetComponent<PlayerController>().canAttack) {
            Vector2 angle = mousePosition - GameObject.Find("Player_Cyborg").transform.parent.transform.position;
            shotBy = GameObject.Find("Player_Cyborg").transform.parent.gameObject.name;

            if (GameObject.Find("Player_Cyborg").transform.parent.GetComponent<PlayerController>().FacingRight) {
                if (angle.x < 0)
                {
                    GameObject.Find("Player_Cyborg").transform.parent.GetComponent<PlayerController>().Flip();
                }
                rbBullet.AddForce(angle.normalized * speed, ForceMode2D.Impulse);
            }
            else 
            {
                if (angle.x > 0)
                {
                    GameObject.Find("Player_Cyborg").transform.parent.GetComponent<PlayerController>().Flip();
                }
                rbBullet.AddForce(angle.normalized * speed, ForceMode2D.Impulse);
            }
        }
        else if (GameObject.Find("Player_Punk") != null && GameObject.Find("Player_Punk").transform.parent.GetComponent<PlayerController>().canAttack)
        {
            Vector2 angle = mousePosition - GameObject.Find("Player_Punk").transform.parent.transform.position;
            shotBy = GameObject.Find("Player_Punk").transform.parent.gameObject.name;

            if (GameObject.Find("Player_Punk").transform.parent.GetComponent<PlayerController>().FacingRight) {
                if (angle.x < 0)
                {
                    GameObject.Find("Player_Punk").transform.parent.GetComponent<PlayerController>().Flip();
                }
                rbBullet.AddForce(angle.normalized * speed, ForceMode2D.Impulse);
            }
            else 
            {
                if (angle.x > 0)
                {
                    GameObject.Find("Player_Punk").transform.parent.GetComponent<PlayerController>().Flip();
                }
                rbBullet.AddForce(angle.normalized * speed, ForceMode2D.Impulse);
            }
        } else if (GameObject.Find("Player_Biker") != null && GameObject.Find("Player_Biker").transform.parent.GetComponent<PlayerController>().canAttack) 
        {
            Vector2 angle = mousePosition - GameObject.Find("Player_Biker").transform.parent.transform.position;
            shotBy = GameObject.Find("Player_Biker").transform.parent.gameObject.name;

            if (GameObject.Find("Player_Biker").transform.parent.GetComponent<PlayerController>().FacingRight) {
                if (angle.x < 0)
                {
                    GameObject.Find("Player_Biker").transform.parent.GetComponent<PlayerController>().Flip();
                }
                rbBullet.AddForce(angle.normalized * speed, ForceMode2D.Impulse);
            }
            else 
            {
                if (angle.x > 0)
                {
                    GameObject.Find("Player_Biker").transform.parent.GetComponent<PlayerController>().Flip();
                }
                rbBullet.AddForce(angle.normalized * speed, ForceMode2D.Impulse);
            }
        }
        else if (GameObject.Find("Player_Biker") != null && Vector2.Distance(GameObject.Find("Player_Biker").transform.position, transform.position) < 1)
        {
            if (GameObject.Find("Player_Biker").transform.parent.GetComponent<PlayerController>().FacingRight)
            {
                rbBullet.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
            else
            {
                rbBullet.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        }
        else
        {
            //Debug.Log("RIP");
        }
        Debug.Log(shotBy);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Destroy ground upon collision
        if (hitInfo.CompareTag("Ground"))
        {
            //if(!hitInfo.CompareTag("Player") &&!hitInfo.CompareTag("Projectile") && !hitInfo.CompareTag("Weapon 1") && !hitInfo.CompareTag("Weapon 2") && !hitInfo.CompareTag("Weapon 3") && !hitInfo.CompareTag("Weapon 4") && !hitInfo.CompareTag("Weapon 5") && !hitInfo.CompareTag("Weapon 6") && !hitInfo.CompareTag("Weapon 7") && !hitInfo.CompareTag("Weapon 8") && !hitInfo.CompareTag("Weapon 9") && !hitInfo.CompareTag("Weapon 10")){
            //Debug.Log(hitInfo.name);
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        // Damage player upon collision
        else if (hitInfo.CompareTag("Player") && !hitInfo.name.Equals(shotBy))
        {
            PlayerHealth playerHealth = hitInfo.gameObject.GetComponent<PlayerHealth>();
            // NOTE: change this so it's not a hardcoded value; perhaps add a 'public int damage' field to the bullet?
            playerHealth.TakeDamage(10);

            //Debug.Log(hitInfo.name);

            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}