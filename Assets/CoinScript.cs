using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public LogicScript logic;

    public float rotateSpeed = 5f;
    public SpriteRenderer coin;
    public AudioSource source;
    public AudioClip coinCollectSound;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        coin.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //source.PlayClipAtPoint(coinCollectSound, transform.position);
            AudioSource.PlayClipAtPoint(coinCollectSound,transform.position);
           // source.PlayOneShot(coinCollectSound);
            logic.addCoin(1);
            Destroy(gameObject);
        }
    }
}
