
using System;
using UnityEngine;


public abstract class Object: MonoBehaviour{
    public int ID;
    public string nameObject;

    public int level;

    //public  void AddLevel(int lv);

    public virtual void AddLevel(int lv)
    {
        this.level += lv;
        LevelUp();
        Debug.Log(tag + ": " + level);
        EffectLevelUp();
    }

    public virtual void EffectLevelUp()
    {
        
    }

    //protected virtual void LevelUp();


    private void LevelUp()
    {
        if (level >= 3)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1) * 1.2f;
            
        }
        if (level >= 6)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1) * 1.5f;
            
        }
    }
}
     
