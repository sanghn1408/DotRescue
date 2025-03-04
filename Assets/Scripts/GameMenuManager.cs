using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _newscoreText;
    [SerializeField] private TMP_Text _bestscoreText;

    private void Awake()
    {
        _bestscoreText.text = GameManager.Instance.HighScore.ToString();
       

        if(!GameManager.Instance.IsInitialized)
        {
            _scoreText.gameObject.SetActive(false);
            _newscoreText.gameObject.SetActive(false);
        }
        else
        {
           StartCoroutine(ShowScore());
        }
    }

    [SerializeField] private AnimationCurve _speedCrurve;
    [SerializeField] private float _animationtime ;
    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();
        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;
        if (currentScore < highScore)
        {
            _newscoreText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currentScore;
        }
        else
        {
            _newscoreText.gameObject.SetActive(false);
        }
        _bestscoreText.text = GameManager.Instance.HighScore.ToString();
        float speed = 1 / _animationtime;
        float timeElapsed = 0;
        while (timeElapsed < 1)
        {
            timeElapsed += Time.deltaTime * speed;
            tempScore = (int)_speedCrurve.Evaluate(timeElapsed * currentScore);
            _scoreText.text = tempScore.ToString();
            yield return null;
        }
        tempScore = currentScore;
        _scoreText.text = tempScore.ToString();
    }

    [SerializeField] private AudioClip _clickClip;

    public void ClikedPlay()
    {
        SoundManager.Instance.PlaySound(_clickClip);
        GameManager.Instance.GotoGameplay();
    }
}
