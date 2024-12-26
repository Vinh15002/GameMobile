
using System;
using System.Collections;

using Assets.Scripts.Animation;

using Assets.Scripts.Weapon;
using UnityEngine;

public class ObjectAttack: MonoBehaviour{
    public static float timeToRemove = 0.3f;
    [SerializeField]protected GameObject weaponOnHand;
    [SerializeField] protected GameObject weaponRangeAttack;
    [SerializeField] protected Transform offset;
    [SerializeField] protected float timeToAttack = 1.2f;

    protected const float rangeAttack = 40f;
    private float _timeToAttack = 0;
   

    protected Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

   
    private void FixedUpdate()
    {
        CheckAttack();   
    }

    private void CheckAttack()
    {
        if (!animator.GetBool(AnimationString.IsAttack))
        {
            weaponOnHand.SetActive(true);
        }
        if(_timeToAttack >= 0){
            _timeToAttack -= Time.deltaTime;
        }
    }

    protected void HandleAttack(Vector3 positon, int ID)
    {

        
        if (!animator.GetBool(AnimationString.IsAttack) && !GetComponent<ObjectMovement>().IsMoving && _timeToAttack <= 0)
        {
            Vector3 direction = positon - transform.position;
            direction.Normalize();  
            direction = new Vector3(direction.x, 0, direction.z);
            GetComponent<ObjectMovement>().handleRoration(direction);
            StartCoroutine(removeWeaponCountine(direction, ID));
            _timeToAttack = timeToAttack;
            
        }

    }

    public IEnumerator removeWeaponCountine(Vector3 direction, int ID)
    {
        animator.SetBool(AnimationString.IsAttack, true);
        yield return new WaitForSeconds(timeToRemove);
        weaponOnHand.SetActive(false);
        RangeAttack(direction, ID);
    }

    protected void RangeAttack(Vector3 direction,int  ID)
    {
        
        if(!GetComponent<ObjectMovement>().IsMoving)
        {
            GameObject game = Instantiate(weaponRangeAttack, offset.position, Quaternion.Euler(90,0,0));
            game.GetComponent<Weapon>().direction = direction;
            game.GetComponent<Weapon>().onwer = gameObject;
            game.GetComponent<Weapon>().distanceToDestroy = rangeAttack;

        }
     
    }






}