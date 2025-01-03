
using System;
using Assets.Scripts.Event;
using UnityEngine;

public class Target : MonoBehaviour
{


    public static Target Instance;


    [SerializeField] private GameObject targetUI;

    private void Awake()
    {
        Instance = this;
    }

    public bool hasTarget = false;




    public GameObject targetEnemy;


   

    private void Update() {

        setDisplayTarget();
        
    }

    private void setDisplayTarget()
    {

        if (hasTarget)
        {
            Vector3 positionEnemy = targetEnemy.transform.position;
            positionEnemy.y = 0.5f;
            targetUI.transform.position = positionEnemy;
            FindEnemyEvent.findEnemy?.Invoke(targetUI.transform.position);
        }
        else
        {
            targetUI.SetActive(false);
        }

        if (targetEnemy != null && !targetEnemy.activeSelf) {
            targetUI.SetActive(false);
            targetEnemy = null;
            hasTarget = false;
        }






    }

    public void HasEnemy(GameObject target)
    {
        hasTarget = true;
        targetEnemy = target;
        targetUI.SetActive(true);
    }

    public void SetDisActive()
    {
        hasTarget = false;
        targetUI.SetActive(false);
    }
}
