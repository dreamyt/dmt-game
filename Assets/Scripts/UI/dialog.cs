using UnityEngine;

public class dialog : MonoBehaviour
{
    public GameObject Talk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Talk.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Talk.SetActive(false);
        }
    }
}