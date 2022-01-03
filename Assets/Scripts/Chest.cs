using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject coin;
    //public GameObject medicine;

    private bool canOpen;
    private bool isOpened;
    private Animator anim;

    public Vector3 rewardRandomPosition;

    //public int keyNum;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
        //keyNum = GameObject.Find("Key").GetComponent<Key>().keyNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GameObject.Find("Key").GetComponent<Key>().keyNum > 0)
        {
            if (canOpen && !isOpened)
            {
                rewardRandomPosition.y = 3;

                anim.SetTrigger("Opening");
                isOpened = true;
                Instantiate(coin, transform.position, Quaternion.identity);
                //Instantiate(medicine, transform.position+ rewardRandomPosition, Quaternion.identity);
                Instantiate(coin, transform.position + rewardRandomPosition, Quaternion.identity);
                GameObject.Find("Key").GetComponent<Key>().keyNum -= 1;
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = false;

        }
    }
}
