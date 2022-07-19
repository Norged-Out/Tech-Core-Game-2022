using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script in order to allow the player to move, jump, and shoot.
 * You must apply this script to the player object, and specify the projectile 
 * prefab in the inspector.
 * 
 * At a later point, it'll probably be better to move weapon functionality to a
 * seperate script, then call that script from within this one. For now, I'll use
 * a basic projectile (like prototype 2).
 * 
 * Author: Jamie Taube
 */
public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float speed = 20.0f;
    private float horizontalInput;

    private Vector3 jumpDirection = Vector3.up;
    private Vector3 moveDirection = Vector3.right;
    
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public int maxJumps = 2;
    private int jumps;
    public float gravityModifier = 1;
    private bool isOnGround = true;

    private bool canMove;
    private int movementTime = 10; // time in seconds

    private bool canAttack;
    private int attackTime = 30; // time in seconds 
    private Vector3 projectileOffset = Vector3.up * 2;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        canMove = true;
        canAttack = false;
        StartCoroutine(MovementCountdownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        // Left/right player movement with A, D keys
        horizontalInput = Input.GetAxis("Horizontal");
        if (canMove)
        {
            // Calculate vector in direction of intended movement
            Vector3 movement = horizontalInput * moveDirection;

            // When the player is moving, rotate to face the direction of movement
            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(movement);
            }
            // Move the player
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        
        // Jump with space key
        // NOTE: Make sure that the player object has a RigidBody component with gravity enabled!
        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            Jump();    
        }

        // Launch a projectile from the player on left click
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Instantiate(projectilePrefab, transform.position + projectileOffset, transform.rotation); //projectilePrefab.transform.rotation);
        }
    }

    // Method to control the double jump mechanic
    private void Jump()
    {
        if (jumps > 0)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            jumps = jumps - 1;
        }
        if (jumps == 0)
        {
            return;
        }
    }

    // Determine if the player has collided with an object, such as the ground.
    // NOTE: Make sure the player has a Collider component of some kind, and
    // that the ground is tagged as "Ground"
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = maxJumps;
            isOnGround = true;
        }
    }

    // Timer to control how long a player can move for
    IEnumerator MovementCountdownRoutine()
    {
        yield return new WaitForSeconds(movementTime);
        canMove = false;

        // Need to call the turn timer within move routine to have sequential execution
        StartCoroutine(AttackTurnCountdownRoutine());
    }

    // Timer to control how long a player's turn (i.e. attack time) lasts for
    IEnumerator AttackTurnCountdownRoutine()
    {
        canAttack = true;
        yield return new WaitForSeconds(attackTime);
        canAttack = false;
    }
}