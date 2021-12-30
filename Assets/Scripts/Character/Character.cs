using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour
{
    public enum CharacterTypes
    {
        player,
        AI
    }
    [SerializeField] private CharacterTypes characterType;
    public CharacterTypes CharacterType => characterType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}