using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float interval_shot;

    [SerializeField] float lange_move;

    [SerializeField] GameObject bullet;

    [SerializeField] GameObject Director;

    GameDirector GD;

    float timer = 0;

    void Start()
    {
        GD = Director.GetComponent<GameDirector>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < lange_move) transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > lange_move * -1) transform.Translate(new Vector3(speed * Time.deltaTime * -1, 0, 0));

        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0f)
        {
            Shot();

            timer = interval_shot;
        }

        if(timer > 0f) timer -= Time.deltaTime;
    }

    void Shot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public void HitToEnemiesBullet()
    {
        GD.playerDamaged();
    }
}
