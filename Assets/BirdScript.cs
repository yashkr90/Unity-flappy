using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public Animator animator;
    public bool birdisAlive = true;

    public float rotationSpeed = 10f;
    
    public AudioClip flap;
    public AudioClip die;
    public AudioClip hit;

    public AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Birdinton";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space)==true || Input.GetMouseButtonDown(0)) && birdisAlive==true)
        {
          
            myRigidBody.velocity = Vector2.up * flapStrength;
            source.PlayOneShot(flap);
            
        }
        animator.SetBool("isAlive", birdisAlive);
       

    }

    private void FixedUpdate()
    {
        transform.rotation= Quaternion.Euler(0f, 0f, myRigidBody.velocity.y*rotationSpeed);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( birdisAlive)
            source.PlayOneShot(hit);
        birdisAlive = false;
        if (collision.gameObject.CompareTag("Pipe"))
            source.PlayOneShot(die);
        logic.gameOver();
    }
}
