using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] int defHP;

    float hp;

    float defSize;

    private void Start()
    {
        hp = defHP;

        defSize = transform.localScale.x;
    }

    public void Damaged(int x)
    {
        hp -= x;

        transform.localScale = new Vector3(defSize * hp / defHP, transform.localScale.y, 1);

        if (hp <= 0) Destroy(gameObject);
    }
}
