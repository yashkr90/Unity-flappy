using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModScript : MonoBehaviour
{


 
    public BirdScript bird;
    Rigidbody2D rigid;
    public bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
 
        rigid = bird.GetComponent<Rigidbody2D>();
    }

    public void PointerDown()
    {
        Debug.Log("Ponierdown");
        buttonPressed=true;
    }
     public void PointerUp()
    {
        Debug.Log("PonierUp");
        buttonPressed =false;
    }

     void Update()
    {
        if(buttonPressed)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.None;
        }
    }




}
