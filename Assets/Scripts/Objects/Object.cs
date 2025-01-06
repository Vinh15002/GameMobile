
using Assets.Scripts.Event;
using Assets.Scripts.Objects;
using Assets.Scripts.Ultils;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public abstract class Object: MonoBehaviour{
  

    public ObjectDataSO data;



    public GameObject body;



 
    [HideInInspector]public string nameObject;

    [HideInInspector]public int level;

    public UnityEvent<int> ActionLevelUp;
    [SerializeField] protected GameObject bodySkin;
    [SerializeField] protected GameObject panSkin;
    [SerializeField] protected GameObject weaponSkin;
    [SerializeField] protected GameObject playerHat;
    [SerializeField] protected GameObject playerShiled;
    [SerializeField] protected GameObject playerBack;



    public UnityEvent<string, Color> SetupUI;

    private void Start()
    {
        SetData();
    }
    private void OnEnable()
    {
        SetData();
    }
    public void SetData()
    {
        bodySkin.GetComponent<SkinnedMeshRenderer>().material= data.bodyMaterial;
        panSkin.GetComponent<SkinnedMeshRenderer>().material = data.pansMaterial;
        weaponSkin.GetComponent<MeshFilter>().mesh = data.meshWeapon;
        weaponSkin.GetComponent<MeshRenderer>().materials = data.materials;
        playerHat.GetComponent<SetDisplayItem>().SetActive(data.idHat);
        playerShiled.GetComponent<SetDisplayItem>().SetActive(data.idShield);
        playerBack.GetComponent<SetDisplayItem>().SetActive(data.idBack);
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
        ActionLevelUp.Invoke(level);
    }
}
     
