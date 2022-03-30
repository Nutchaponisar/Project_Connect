using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LineAttack : NetworkBehaviour
{
    [SerializeField]private int lineDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyController>();
        if (collision.tag == "Enemy")
        {
            enemy.TakeDamage(lineDamage);
            Debug.Log($"EnemyGetDamage : {lineDamage}");
        }
    }
}
