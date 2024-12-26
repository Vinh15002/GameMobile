using Assets.Scripts.Event;

using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerFindEnemy : ObjectFindEnemy
    {

        [SerializeField] private GameObject targetEnemy;
        private Vector3 positionEnemy;

        public bool checkHasEnemy = false; 




        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy") && !targetEnemy.activeSelf)
            {
                targetEnemy.SetActive(true);
                positionEnemy = other.transform.position;
                FindEnemyEvent.targetEnemy?.Invoke(other.gameObject);
                checkHasEnemy = true;
            }

           
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Enemy"))
            {
                checkHasEnemy = false;
                targetEnemy.SetActive(false);
            }
            if(other.CompareTag("Decorator")){
                other.GetComponent<ConvertState>().SetOut();
            }
        }

        private void OnTriggerEnter(Collider other) {
            if(other.CompareTag("Decorator")){
                other.GetComponent<ConvertState>().SetIn();
            }
        }

    }
}
