

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : ObjectHealth
{
    public UnityEvent deadEvent;



    private void FixedUpdate() {
        if(currentHeal <= 0){
            StartCoroutine(DestroyObject());
            
        }
    }

    private IEnumerator DestroyObject()
    {
        deadEvent?.Invoke();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
} 