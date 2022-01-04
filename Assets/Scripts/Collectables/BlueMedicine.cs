using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMedicine : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public int BlueMedicineNum;

    [SerializeField] private ParticleSystem medicineBonus;

    public AudioSource MedicineAudio;
    
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
            MedicineAudio.Play();
            PlayEffects();
            sr.enabled = false;
            bc.enabled = false;
            CharacterSpell characterSpell = collision.gameObject.GetComponent<CharacterSpell>();
            characterSpell.currentMagicPower += 5;
            if (characterSpell.currentMagicPower>=characterSpell.maxMagicPower)
            {
                characterSpell.currentMagicPower = characterSpell.maxMagicPower;
            }
            
            UIManager.Instance.UpdateMagic(characterSpell.currentMagicPower, characterSpell.maxMagicPower);

        }
    }
}
