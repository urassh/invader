using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed_y;
    [SerializeField] float speed_x;
    [SerializeField] int defaultHP;

    int HP;

    float verocity_x = 1;

    [SerializeField] int score;

    float timer;

    [SerializeField] GameObject bullet;

    [SerializeField] float interval_shoot;

    void Start()
    {
        HP = defaultHP;

        int p = Random.Range(1, 3);
        if (p == 2) p = -1;

        verocity_x = p;
    }

    void Update()
    {
        transform.Translate(new Vector3(speed_x * Time.deltaTime * verocity_x, -1 * speed_y * Time.deltaTime, 0));

        if(timer < 0)
        {
            shoot();

            timer = interval_shoot;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 180));
    }

    public void Damaged(int x)
    {
        HP -= x;

        if (HP <= 0)
        {
            GameObject.Find("Director").GetComponent<GameDirector>().AddScore(score);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) verocity_x *= -1;
    }
}
