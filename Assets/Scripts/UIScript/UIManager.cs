using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]private GameObject _pauseMenu,_gameOverMenu;
    [SerializeField]private GameObject _scoretext,_playerInt;
    [SerializeField]private TMP_Text _currentScore;
    private void Start()
    {
        Time.timeScale = 0;
        if(_pauseMenu != null)
        {
            _pauseMenu.SetActive(false);
            
            _playerInt.SetActive(true);
            _gameOverMenu.SetActive(false);
        }
        if(_scoretext!= null)
        _scoretext.SetActive(false);
       // _pauseMenu.SetActive(false);
       // _scoretext.SetActive(false);
       
        

    }//Start

    public void Play()
    {
        SceneManager.LoadScene(1);
    }//Play
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit!");
        
    }//Exit
    public void Exit2()
    {
        _gameOverMenu.SetActive(false);
        SceneManager.LoadScene(0);
        Debug.Log("Exit!");
        
    }//Exit2
    public void Restart()
    {
        //if(_pauseMenu == null){return;}
        SceneManager.LoadScene(1);
        _pauseMenu.SetActive(false);
        _gameOverMenu.SetActive(false);
    }//Resume
    public void Resume()
    {
        //if(_pauseMenu == null){return;}
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }//Resume
    public void ResetScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //if(_pauseMenu == null){return;}
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            Time.timeScale = 1;
            _scoretext.SetActive(true);
            _playerInt.SetActive(false);
        }
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            _currentScore.text =$"HighScore :  {PlayerPrefs.GetInt("HighScore")}";
        }

    }//Update
    

}//Class
