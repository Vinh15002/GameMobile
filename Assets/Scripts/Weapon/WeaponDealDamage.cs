
using Assets.Scripts.Weapon;
using UnityEngine;

public class WeaponDealDamage : Weapon
{
    [SerializeField]
    private int damage = 1;


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy") && !other.gameObject.Equals(onwer)){
            other.GetComponent<InterfaceHealth>().TakeDamge(damage,onwer);
            gameObject.SetActive(false);

        }
        if (other.CompareTag("Player") && !other.gameObject.Equals(onwer))
        {
            other.GetComponent<InterfaceHealth>().TakeDamge(damage, onwer);
            gameObject.SetActive(false);

        }

    }


   
}
