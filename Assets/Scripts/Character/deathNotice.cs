using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathNotice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Notice;
    public GameObject Notice2;
    private Health h;
    void Start()
    {
        h = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (h.dead)
        {
            Debug.Log("die");
            if(CoinManager.Instance.isTimeout)
                Notice2.SetActive(true);
            else
            {
                Notice.SetActive(true);
            }
            
        }
        else
        {
            Notice.SetActive(false);
            Notice2.SetActive(false);
        }
    }
    
    
}
