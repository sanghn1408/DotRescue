using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
   private bool hasgameFinished = false;
    [SerializeField] private TMP_Text _scoreText;

    private float score;
    private float scoreSpeed;
    private int currentLevel;

    [SerializeField] private List<int> _levelSpeed ,_levelMax;

    private void Awake()
    {
        currentLevel = 0;
        score = 0;
        scoreSpeed = _levelSpeed[currentLevel];
        _scoreText.text = ((int)score).ToString();
    }

    public void GameEnded()
    {
        hasgameFinished = true;
        GameManager.Instance.CurrentScore = (int)score;
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.GotoMainMenu();
    }

    private void Update()
    {
        if (hasgameFinished)
        {
            return;
        }
        score += scoreSpeed * Time.deltaTime;
        _scoreText.text = ((int)score).ToString();
        if (score > _levelMax[Mathf.Clamp(currentLevel,0,_levelMax.Count -1)])
        {
           currentLevel = Mathf.Clamp(currentLevel + 1, 0, _levelSpeed.Count - 1);
            scoreSpeed = _levelSpeed[currentLevel];
        }
    }
}


