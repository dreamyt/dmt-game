using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    public AudioSource a;
    private void Start()
    {
        a.Play();
    }
    void Update()
    {

        Destroy(gameObject, 1.0f);
    }
}
