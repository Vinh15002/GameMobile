

using Assets.Scripts.Animation;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour, InterfaceHealth
{
    [SerializeField]
    protected int currentHeal = 1;

    [SerializeField]
    protected int maxHeal = 1;


    public UnityEvent resetEvent;


   
    public bool IsDead(){
        return currentHeal <= 0;
    }

    public void TakeDamge(int damage, GameObject destroyer)
    {
        currentHeal -= damage;
        if(destroyer!= null)
        {
            int level = GetComponent<Object>().level;
            destroyer.GetComponent<Object>().AddLevel(level);
        }
       
        
    }


    public void SetDeadAnimation()
    {
        GetComponent<Animator>().SetBool(AnimationString.IsDead, true);
    }

    public void ResetHeal()
    {
        currentHeal = maxHeal;
        GetComponent<Animator>().SetBool(AnimationString.IsDead, false);
        resetEvent?.Invoke();
    }
}