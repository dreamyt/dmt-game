using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
       public GameObject pauseMenu;
       public AudioMixer audioMixer;
   //pause the game
       public void PauseGame()
       {
           pauseMenu.SetActive(true);
           Time.timeScale = 0;
       }
       //resume the game
   
       public void ResumeGame()
       {
           pauseMenu.SetActive(false);
           Time.timeScale = 1;
       }
       //set the volume
       public void SetVolume(float value)
       {
           audioMixer.SetFloat("MainVolume", value);
       }
       /*public void ExitScene()
       {
           CoinManager.Instance.PullTempCoins();
           SceneManager.LoadScene(0);
           Time.timeScale = 1f;
       }
   
       public void RestartScene()
       {
           CoinManager.Instance.PullTempCoins();
           SceneManager.LoadScene(6);
           Time.timeScale = 1f;
       }*/
}
