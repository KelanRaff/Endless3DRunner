using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{
    public bool alive = true;
    public static event Action OnPlayerDeath;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField]  float horizontalMultiplier = 2;
    [SerializeField] float jumpForce= 400f;
    [SerializeField] LayerMask groundMask;
    public float speedIncreasePerPoint= 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        //Fixed update runs 50 times per second, which gives the physics engine a stable based to work from rather than
        //A frame rate dependant update method.

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.W)){
            Jump();
        }

        if(transform.position.y < -5){
            Die();
        }
    }

    public void Die()
    {
        alive = false;

        OnPlayerDeath?.Invoke();
        //restart the game
        //Invoke("Restart",2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void Jump()
    {
        //check if we are on ground
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2)+ 0.1f, groundMask);

        //if so, jump
        rb.AddForce(Vector3.up * jumpForce);
    }
}
