using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpell : CharacterComponents
{
    /* It's standing for the spell position togehter with the player */
    public int spellMode = 0;
    ObjectPooler Pooler;
    [Header("Spell Settings")]
    [SerializeField] private Vector3 SpellGeneratePosition; // The real position to generate spell attack
    [SerializeField] private Vector3 spellGeneratePosition; // The relative position of spell compared to player

    // Start is called before the first frame update
    void Start()
    {
        spellMode = 0;
        spellGeneratePosition = new Vector3(0f, 0f, 0f);
        Pooler = GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSpellAttacking()
    {
        if(spellMode == 0)
        {
            spellAttackRed();
        }
    }

    private void spellAttackRed()
    {
        GameObject projectilePooled = Pooler.GetObjectFromPool();
        SpellGeneratePosition = transform.position + spellGeneratePosition;
        projectilePooled.transform.position = SpellGeneratePosition;
        projectilePooled.SetActive(true);

    }

}
