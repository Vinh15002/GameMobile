
using System;
using System.Collections;

using Assets.Scripts.Animation;
using Assets.Scripts.Pooling;
using Assets.Scripts.Weapon;
using UnityEngine;

public class ObjectAttack: MonoBehaviour{
    public static float timeToRemove = 0.3f;
    [SerializeField]protected GameObject weaponOnHand;

    [SerializeField] protected Transform offset;
    [SerializeField] protected float timeToAttack = 1.2f;

    protected const float RANGE_ATTACK = 30f;
    private float _timeToAttack = 0;
   

    protected Animator animator;

    private void OnEnable() {
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

    protected void HandleAttack(Vector3 positon)
    {
        

        if (!animator.GetBool(AnimationString.IsAttack) && _timeToAttack <= 0 && !GetComponent<ObjectMovement>().IsMoving)
        {
            Vector3 direction = positon - transform.position;
            direction.Normalize();  
            direction = new Vector3(direction.x, 0, direction.z);
            GetComponent<ObjectMovement>().handleRoration(direction);
            StartCoroutine(removeWeaponCountine(direction));
            _timeToAttack = timeToAttack;
            
        }

    }

    public IEnumerator removeWeaponCountine(Vector3 direction)
    {
        animator.SetBool(AnimationString.IsAttack, true);
        yield return new WaitForSeconds(timeToRemove);
        weaponOnHand.SetActive(false);
        RangeAttack(direction);
    }

    protected void RangeAttack(Vector3 direction)
    {
        if (animator.GetBool(AnimationString.IsDead)) return;
        if(!GetComponent<ObjectMovement>().IsMoving)
        {
            Vector3 scale = GetComponent<Object>().body.transform.localScale;
            GameObject game = WeaponPooling.Instance.SpawnWeapon(
                GetComponent<Object>().data.typeWeapon
                );

           
            game.transform.rotation = Quaternion.Euler(90, 0, 0);
            game.transform.position = offset.position;
            game.transform.localScale = scale*39;
           
            game.GetComponent<Weapon>().direction = direction;
            game.GetComponent<Weapon>().onwer = gameObject;
            game.GetComponent<Weapon>().distanceToDestroy = RANGE_ATTACK * scale.x;

            game.SetActive(true);

        }
     
    }






}