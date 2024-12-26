

using UnityEngine;

public class EnemyFindEnemy :  ObjectFindEnemy {


    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") || other.CompareTag("Enemy")){
            GetComponentInParent<EnemyAttack>().Attack(other.transform.position);
        }
    }


}