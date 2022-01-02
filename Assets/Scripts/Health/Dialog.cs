using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject attack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            attack.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            attack.SetActive(false);
        }
    }
}