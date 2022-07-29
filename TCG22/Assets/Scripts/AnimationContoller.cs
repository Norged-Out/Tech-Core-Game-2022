using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContoller : MonoBehaviour
{

    // Stores Animator For Character
    private Animator animator;
    public bool Direction = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player has a weapon
        if (this.transform.childCount != 0)
        {
            animator.SetBool("hasWeapon", true);
        }
        else 
        {
            animator.SetBool("hasWeapon", false);
        }

        // Checks if Player is Running and that they ARE NOT jumping
        if (Input.GetAxis("Horizontal") != 0 && !Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Checks if Player is Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.transform.childCount != 0)
            {
                animator.Play("Jump2");
            }
            else
            {
                animator.Play("Jump1");
            }
        }
       

        // Rotates Player to Face Correct Direction
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.eulerAngles = new Vector3(0, 180f, 0);


        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
