using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu1 : MonoBehaviour
{
    public GameObject pauseMenu;

    //public AudioMixer audioMixer;
    public void PlayGame()
    {
        CoinManager.Instance.PushTempCoins();
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void UIEnable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
                 UnityEditor.EditorApplication.isPlaying = false;
        
    #else
        Application.Quit();
     #endif
    }

    public void Introduction()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //public void SetVolume(float value)
    //{
    //    audioMixer.SetFloat("MainVolume", value);
    //}
    public void PlayLevel1()
    {
        CoinManager.Instance.PushTempCoins();
        SceneManager.LoadScene(2);
    }

    public void PlayLevel2()
    {
        CoinManager.Instance.PushTempCoins();
        SceneManager.LoadScene(3);
    }

    public void PlayLevel3()
    {
        CoinManager.Instance.PushTempCoins();
        SceneManager.LoadScene(4);
    }

    public void PlayLevel4()
    {
        CoinManager.Instance.PushTempCoins();
        SceneManager.LoadScene(5);
    }

    public void PlayLevel5()
    {
        CoinManager.Instance.PushTempCoins();
        SceneManager.LoadScene(6);
    }

    public void PlayLevel6()
    {
        CoinManager.Instance.PushTempCoins();
        SceneManager.LoadScene(7);
    }
    public void ExitScene()
    {
        CoinManager.Instance.PullTempCoins();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        CoinManager.Instance.PullTempCoins();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

}
