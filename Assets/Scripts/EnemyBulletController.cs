using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int power;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if(transform.position.y < -7) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().HitToEnemiesBullet();

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.GetComponent<ShieldController>().Damaged(power);

            Destroy(gameObject);
        }
    }
}
