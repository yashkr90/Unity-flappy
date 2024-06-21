using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public GameObject coin;
    private float length;
    private float middle;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // length = GetComponent<CircleCollider2D>().bounds.size.y/3;


        //coin spawn script 
        SpawnCoin();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCoin()
    {
        middle = GetComponent<BoxCollider2D>().bounds.size.y / 2;
        float offset = Mathf.Abs(middle / 2);

        int numberOfCoins = Random.Range(0, 4);

        for (int i = 0; i < numberOfCoins; i++)
        {
            float yOffset = offset * (i == 0 ? 0 : i % 2 == 0 ? 1 : -1);  // Alternating signs for even and odd iterations

            GameObject obj = Instantiate(coin, new Vector3(transform.position.x, transform.position.y + yOffset + 0.1f, transform.position.z), transform.rotation) as GameObject;
            //obj.transform.SetAsFirstSibling();
            obj.transform.SetParent(transform);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }
        //Debug.Log("colied");
    }
}
