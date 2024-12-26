
using System;
using Assets.Scripts.Event;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameObject targetEnemy;


    private void OnEnable() {
        FindEnemyEvent.targetEnemy += setDisplayUI;
    }

    private void OnDisable() {
        FindEnemyEvent.targetEnemy -= setDisplayUI;
    }

    private void setDisplayUI(GameObject enemy)
    {
        targetEnemy = enemy;
    }
    private void FixedUpdate() {

        setDisplayTarget();
        
    }

    private void setDisplayTarget()
    {
        if(targetEnemy!= null){
          
            
            Vector3 positionEnemy = targetEnemy.transform.position;
            positionEnemy.y = 0.5f;
            transform.position = positionEnemy;
            FindEnemyEvent.findEnemy?.Invoke(positionEnemy);
         
           
        }
        else {
            gameObject.SetActive(false);
        }

        
       

        
       
    }
}
