using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public BirdScript bird;
    int scoreThreshold = 3;
    public float initialSpeed = 6f;
    public  float speedIncrement = 0.4f;
    public float initialSpawnRate = 4f;
    public float spawnRateDecrement = 0.3f;
    public float movespeed = 5;
    private float deadZone = -35;
    public pipeSpawnScript pipeSwapner;

    public LogicScript logic;


    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSwapner= GameObject.Find("PipeSpawner").GetComponent<pipeSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.birdisAlive)
        {
          transform.position = transform.position + (Vector3.left * movespeed) * Time.deltaTime;
        }
        //if(logic.playerScore > 4 && logic.playerScore <=6)
        //{
        //    movespeed =6;
        //    pipeSwapner.spawnRate = 4;

        //}
        //else if (logic.playerScore >6 && logic.playerScore <=9)
        //{
        //    movespeed = 6.5f;
        //    pipeSwapner.spawnRate = 3;
        //}
        //else if (logic.playerScore > 9 && logic.playerScore <=13)
        //{
        //    movespeed = 7.5f;
        //    pipeSwapner.spawnRate = 3;

        //}
        //else if (logic.playerScore > 13 && logic.playerScore <= 16)
        //{
        //    movespeed = 8f;
        //    pipeSwapner.spawnRate = 2;

        //}
        //else if (logic.playerScore > 16 && logic.playerScore <= 18)
        //{
        //    movespeed = 9f;
        //    pipeSwapner.spawnRate = 2;

        //}
        //else if (logic.playerScore > 18)
        //{
        //    movespeed = 11f;
        //    pipeSwapner.spawnRate = 1;

        //}

        if (logic.playerScore > scoreThreshold )
        {
            scoreThreshold += 3;
            int scoreDifference = logic.playerScore - scoreThreshold;

            // Cap values if needed
            if (movespeed + speedIncrement > 11f)
            {
                movespeed = 11f;
            }
            else
            {
                movespeed += speedIncrement;
            }

            if (pipeSwapner.spawnRate - spawnRateDecrement < 1f)
            {
                pipeSwapner.spawnRate = 1.8f;
            }
            else
            {
                pipeSwapner.spawnRate -= spawnRateDecrement;
            }
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
