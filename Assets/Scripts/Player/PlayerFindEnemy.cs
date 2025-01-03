using Assets.Scripts.Event;

using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerFindEnemy : ObjectFindEnemy
    {





        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy") && !Target.Instance.hasTarget)
            {
                Target.Instance.HasEnemy(other.gameObject);
            }
        }


        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Enemy") && other.gameObject.Equals(Target.Instance.targetEnemy))
            {

                Target.Instance.SetDisActive();
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
