
using UnityEngine;
using System.Collections;




public class EnterDialog : MonoBehaviour
{
    
    public GameObject enterDialog; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            //if(isDialog)
                enterDialog.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enterDialog.SetActive(false);
    }
}
