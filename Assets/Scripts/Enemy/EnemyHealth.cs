

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : ObjectHealth
{
    public UnityEvent deadEvent;



    private void FixedUpdate() {
        if(IsDead()){
            StartCoroutine(DestroyObject());
            
        }
    }

    private IEnumerator DestroyObject()
    {
        deadEvent?.Invoke();
        SetDeadAnimation();
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
} 