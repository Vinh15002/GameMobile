using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Animation;
using UnityEngine;

public class EnemyAttack : ObjectAttack
{
    public void Attack(Vector3 position)
    {
        GetComponent<EnemyMovement>().movementDirection = Vector3.zero;
        HandleAttack(position);
        
    }
}
