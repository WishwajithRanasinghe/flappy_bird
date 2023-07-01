using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PayerUIScript : MonoBehaviour
{
    [SerializeField]private Text _scoreText,_overScoretext,_highScore,_highScorePlay;
    [SerializeField]private GameObject _gameOver;
    private BirdScript _birdScript
    ;
    private int _uiScore;

    private void Start()
    {
        _birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }//Start


    private void Update()
    {
        _uiScore = _birdScript.Score();
        _scoreText.text = "Score = " + _uiScore.ToString();
        _overScoretext.text = "You'r Score = " + _uiScore.ToString(); 
        _highScore.text = $"HighScore :  {PlayerPrefs.GetInt("HighScore",0)}";
        _highScorePlay.text = $"HighScore :  {PlayerPrefs.GetInt("HighScore",0)}";
        if(_birdScript.Dying() == true)
        {
            _gameOver.SetActive(true);
        }
        CheckHighScore();
        
    }//Update
    private void CheckHighScore()
    {
        if(_uiScore > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", _uiScore);
        }
    }//CheckHighScore
    
}//Class
