

using UnityEngine;

public class ObjectHealth : MonoBehaviour, InterfaceHealth
{
    [SerializeField]
    protected int currentHeal = 1;

    [SerializeField]
    protected int maxHeal = 1;


   
    public bool IsDead(){
        return currentHeal <= 0;
    }

    public void TakeDamge(int damage, GameObject destroyer)
    {
        currentHeal -= damage;
       
        int level = GetComponent<Object>().level;
        destroyer.GetComponent<Object>().AddLevel(level);
        
    }
}