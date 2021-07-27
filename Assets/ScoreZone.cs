using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
   public enum Side { Left, Right} //What side scores a point in this zone
    public Side mySide;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.GetComponent<BallController>().Respawn();
        if (mySide == Side.Left)
            GameManager.instance.Score(true);
        else
            GameManager.instance.Score(false);
    }
}
