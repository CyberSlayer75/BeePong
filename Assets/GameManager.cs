using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public AudioSource oneAway;
    public Text leftText;
    public Text rightText;
    public SpriteRenderer champion;
    public BallController ball;
    Coroutine winnerRoutine = null;
    int leftScore = 0;
    int rightScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        NewGame();
    }

    public void NewGame()
    {
        champion.gameObject.SetActive(false);
        ball.Respawn();
        leftText.text = "0";
        rightText.text = "0";
    }

    public void Score(bool leftSide)
    {
        if (leftSide)
        {
            leftScore++;
            leftText.text = leftScore.ToString();
            if (leftScore == 6)
                oneAway.Play();
        }
        else
        {
            rightScore++;
            rightText.text = rightScore.ToString();
            if (rightScore == 6)
                oneAway.Play();
        }
        if ((rightScore > 6|| leftScore > 6) && winnerRoutine == null)
        {
            winnerRoutine = StartCoroutine(ShowChampion());
        }
    }

    IEnumerator ShowChampion()
    {
        float timer = 0;
        ball.rb.velocity = Vector2.zero;
        champion.gameObject.SetActive(true);
        while(timer < 10f)
        {
            timer += Time.deltaTime;
            champion.transform.localScale = Vector3.Lerp(Vector3.one * 0.25f, Vector3.one * 3f, timer / 10f);
            yield return null;
        }
        leftScore = rightScore = 0;
        NewGame();
        winnerRoutine = null;
    }
}
