
using Assets.Scripts.Event;
using Assets.Scripts.Objects;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public abstract class Object: MonoBehaviour{
  

    public ObjectData data;



    public GameObject body;



 
    [HideInInspector]public string nameObject;

    [HideInInspector]public int level;

    public UnityEvent<int> ActionLevelUp;
    [SerializeField] private GameObject bodySkin;
    [SerializeField] protected GameObject panSkin;
    [SerializeField] private GameObject weaponSkin;

    

    public UnityEvent<string, Color> SetupUI;

    private void Start()
    {
        SetData();
    }
    private void OnEnable()
    {
        SetData();
    }

    private void SetData()
    {
        bodySkin.GetComponent<SkinnedMeshRenderer>().material= data.bodyMaterial;
        panSkin.GetComponent<SkinnedMeshRenderer>().material = data.pansMaterial;
        weaponSkin.GetComponent<MeshFilter>().mesh = data.weapon.GetComponent<MeshFilter>().sharedMesh;
        weaponSkin.GetComponent<MeshRenderer>().materials = data.weapon.GetComponent<MeshRenderer>().sharedMaterials;

        level = data.level;

        body.transform.localScale = new Vector3(1, 1,1);

        nameObject = name;

        SetupUI?.Invoke(data.name, data.mainCoLor);
        
        

    }

    public virtual void AddLevel(int lv)
    {
        this.level += lv;
        LevelUp();
        
        EffectLevelUp();
    }

    public virtual void EffectLevelUp()
    {
        
    }



    private void LevelUp()
    {
        if(level <2)
        {
            body.transform.localScale = Vector3.one*1f;
        }
        else if (level <5)
        {
            body.transform.localScale = Vector3.one * 1.05f;
        }
        else if (level < 9)
        {
            body.transform.localScale = Vector3.one * 1.1f;
        }
        else
        {
            body.transform.localScale = Vector3.one * 1.3f;
        }
            //body.transform.localScale = body.transform.localScale * 1.1f;
        ActionLevelUp.Invoke(level);
        
        
        //SetLevelEvent.setPositonUI?.Invoke(1.5f);
        //SetLevelEvent.setUIScore?.Invoke(level);
    }
}
     
