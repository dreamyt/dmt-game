using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMedicine : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public int RedMedicineNum;

    [SerializeField] private ParticleSystem medicineBonus;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    protected  void PlayEffects()
    {
        Instantiate(medicineBonus, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //pickAudio.Play();

                PlayEffects();
                sr.enabled = false;
                bc.enabled = false;

                RedMedicineNum += 1;
     

        }
    }
}
