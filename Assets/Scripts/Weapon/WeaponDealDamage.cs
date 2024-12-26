
using Assets.Scripts.Weapon;
using UnityEngine;

public class WeaponDealDamage : Weapon
{
    [SerializeField]
    private int damage = 1;


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy") && !other.gameObject.Equals(onwer)){
            other.GetComponent<InterfaceHealth>().TakeDamge(damage,onwer);
        }
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InterfaceHealth>().TakeDamge(damage, onwer);
        }

    }


   
}
