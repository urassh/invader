using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] Text txt_Score;

    int score;

    [SerializeField] int defaultLife;

    int life;

    [SerializeField] Text txt_Life;

    void Start()
    {
        score = 0;
        txt_Score.text = ("SCORE:" + score.ToString().PadLeft(5));

        life = defaultLife;
        txt_Life.text = ("LIFE:" + life);
    }

    public void AddScore(int x)
    {
        score += x;

        txt_Score.text = ("SCORE:" + score.ToString().PadLeft(5));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerDamaged();

            Destroy(collision.gameObject);
        }
    }

    public void playerDamaged()
    {
        life--;

        txt_Life.text = ("LIFE:" + life);

        if(life < 1)
        {
            //ここにゲームオーバー処理
        }
    }
}
