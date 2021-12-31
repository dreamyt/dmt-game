
using UnityEngine;
using System.Collections;




public class muiltipleDialog : MonoBehaviour
{
    private bool isDialog = false;
    private int Case = 0;
    
    

    void Update()
    {
        if (isDialog)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                if (Case == 0)
                    Case = 1;
            if (Input.GetKeyDown(KeyCode.E))
                if (Case == 0)
                    Case = 2;
        }
        if(Case !=0)
            enterDialog0.SetActive(false);
        if( Case == 1)
            if(isDialog)
                enterDialog01.SetActive(true);
        if ( Case == 2)
            if(isDialog)
                enterDialog02.SetActive(true);

    }

    public GameObject enterDialog0;
    public GameObject enterDialog01;
    public GameObject enterDialog02;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           isDialog = true;
            if(Case == 0)
                enterDialog0.SetActive(true);
            else if(Case == 1)
                enterDialog01.SetActive(true);
            else if (Case == 2)
                enterDialog02.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isDialog = false;
            enterDialog0.SetActive(false);
            enterDialog01.SetActive(false);
            enterDialog02.SetActive(false);
        }
    }
}
