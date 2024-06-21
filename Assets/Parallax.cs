using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public float parallaxEf;
    private float speed = -0.01f; //ypu can change this
    private float distFromMiddle = 0; //keep it 0

    public BirdScript bird;
    float repeatWidth;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        repeatWidth = (GetComponent<SpriteRenderer>().bounds.size.x);

        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        Debug.Log(repeatWidth);
    }
    void Update()
    {
        if (bird.birdisAlive)
        {
            distFromMiddle = distFromMiddle + speed;
            float dist = (distFromMiddle * parallaxEf);

            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        }


   
        if (transform.position.x < startpos - repeatWidth)
        {
            transform.position = new Vector3(startpos+2f, transform.position.y, transform.position.z);
            distFromMiddle = 0f;
        }

    }
}
