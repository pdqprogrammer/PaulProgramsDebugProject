using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController1 : MonoBehaviour
{
    //player settings
    public float playerSpeed = 3.0f;

    public float jumpFallAcceleration = 2.5f;
    public float jumpVelocity = 3.0f;
    public float lowJumpMod = 2.0f;
    public bool onGround = false;

    public float liftHeight = 0.3f;
    public GameObject nearPullObject = null;

    public float bounceModifier = 1.0f;
    public float maxSlideMultiplier = 2.0f;
    private float currSlideMultiplier = 1.0f;

    private PlayerStatsScript1 playerStats;
    
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = gameObject.GetComponent<PlayerStatsScript1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!onGround)
            return;

        if (Input.GetButtonDown("Jump"))
        {
            if (onGround)
            {
                rb.velocity = Vector3.up * jumpVelocity;
                onGround = false;
                transform.parent = null;
            }
        }
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();

        if(nearPullObject != null && Input.GetButton("Grab"))
        {
            Vector3 nearPulPos = nearPullObject.transform.position;
            nearPulPos.y = transform.position.y + liftHeight;
            nearPullObject.transform.position = nearPulPos;
        }
    }

    private void PlayerMove()
    {
        Vector3 playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (playerSpeed * currSlideMultiplier);
        transform.LookAt((transform.position + playerMovement));

        playerMovement.y = rb.velocity.y;
        rb.velocity = playerMovement;
    }

    public void PlayerJump ()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (jumpFallAcceleration - 1);
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMod - 1);
        }
        //AudioSource.PlayClipAtPoint(audioJump, this.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision checks
        if (collision.gameObject.tag.Equals("Ground"))
        {
            onGround = true;
            this.transform.parent = collision.transform;
        }

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            //add behavior for hits
            //playerStats.DamagePlayer();
            Debug.Log("Touched the enemy. Lives: " + playerStats.GetHealth());
            //AudioSource.PlayClipAtPoint (audioPain, this.transform.position);
        }

        //
        if (collision.gameObject.tag.Equals("BounceObject"))
        {
            rb.velocity = Vector3.up * jumpVelocity * bounceModifier;
            onGround = false;
            transform.parent = null;
        }
    }

    private void OnCollisionStay (Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Slider"))
        {
            currSlideMultiplier = maxSlideMultiplier;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Slider"))
        {
            currSlideMultiplier = 1.0f;
        }
    }

    public bool InAir()
    {
        if (rb.velocity.y != 0)
            return true;
        else
            return false;
    }
}
