using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int damage = 1;
    [SerializeField] private int health = 3;

    [Header("Reward Position")]
    [SerializeField] private float xRandomPosition = 0f;
    [SerializeField] private float yRandomPosition = 0f;
    [SerializeField] private GameObject[] rewards;

    bool broken = false;
    private bool rewardDelivered;
    private Vector3 rewardRandomPosition;

    public AudioSource JarAudio;
    private void Start()
    {
    }
    private void Update()
    {
        if(broken)
        {
            RewardPlayer();
        }
        if(rewardDelivered)
        {
            JarAudio.Play();
            gameObject.SetActive(false);
        }
    }
    private void RewardPlayer()
    {
        if  (!rewardDelivered)
        {
            rewardRandomPosition.x = xRandomPosition;
            rewardRandomPosition.y = yRandomPosition;
            Instantiate(SelectReward(), transform.position + rewardRandomPosition, Quaternion.identity);

            rewardDelivered = true;
        }
    }
    private GameObject SelectReward()
    {
        int randomRewardIndex = Random.Range(0, rewards.Length);
        for (int i = 0; i < rewards.Length; i++)
        {
            return rewards[randomRewardIndex];
        }

        return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") || other.CompareTag("Spell"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        health--;

        if (health<= 0)
        {
            broken = true;
        }
    }

}
