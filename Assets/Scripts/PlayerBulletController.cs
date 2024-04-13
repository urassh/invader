using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private int power;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

        if(transform.position.y >= 5) Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().Damaged(power);

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.GetComponent<ShieldController>().Damaged(power);

            Destroy(gameObject);
        }
    }
}
