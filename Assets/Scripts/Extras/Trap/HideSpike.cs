using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{
    public GameObject hideSpikeBox;
    private Animator anim;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("damage by hidespike");
            
            StartCoroutine(SpikeAttack());
        }
    }
    
    IEnumerator SpikeAttack()
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Attack");

        Instantiate(hideSpikeBox, transform.position, Quaternion.identity);
    }
}
