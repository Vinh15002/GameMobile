using Assets.Scripts.Animation;
using Assets.Scripts.Event;
using Assets.Scripts.Weapon;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerAttack : ObjectAttack
{
    private void Start()
    {
        animator = GetComponent<Animator>();
        FindEnemyEvent.findEnemy += FoundEnemy;
    }

    private void OnDisable()
    {
        FindEnemyEvent.findEnemy -= FoundEnemy;
    }

    private void FoundEnemy(Vector3 positon)
    {
        HandleAttack(positon, 0);
    }

    
   
}
