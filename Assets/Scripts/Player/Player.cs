


using Assets.Scripts.Animation;
using Assets.Scripts.Event;
using Assets.Scripts.Objects;
using Assets.Scripts.ScripTableObject.Skin;
using Assets.Scripts.Ultils;
using System.Collections;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class Player : Object
{

    [SerializeField]
    private GameObject effectLevelUp;

    [SerializeField] private Material bodyPlayerOrigin;
    [SerializeField] private Material pantPlayerOrign;





    public static Player instance;

    private void Awake()
    {
        
        instance = this;
    }

    private void FixedUpdate()
    {
        ArrowEvent.Arrow?.Invoke(transform);
    }

    public override void EffectLevelUp()
    {
        StartCoroutine(LevelUpCountine());

    }

    public IEnumerator  LevelUpCountine()
    {
        effectLevelUp.SetActive(true);
        yield return new  WaitForSeconds(0.5f);
        effectLevelUp.SetActive(false);

    }


    public void SetDanceEnabled()
    {
        GetComponent<Animator>().SetBool(AnimationString.IsDance, true);
    }

    public void SetDanceDisaabled()
    {
        GetComponent<Animator>().SetBool(AnimationString.IsDance, false);
    }

    public void ChangePants(DataSkinPant data, bool value)
    {
        ResetData();
        panSkin.GetComponent<SkinnedMeshRenderer>().material = data.materials[0];

        if(value)
        {
            this.data.pansMaterial = data.materials[0];
            SetData();
        }
    }

    public void ChangeHat(int idHat, bool isSelect)
    {
        ResetData();
        playerHat.GetComponent<SetDisplayItem>().SetActive(idHat);
        if(isSelect)
        {
            this.data.idHat = idHat;
            SetData();
        }
   
    }

    public void ChangeShield(int idShield, bool isSelect)
    {
        ResetData();
        playerShiled.GetComponent<SetDisplayItem>().SetActive(idShield);
        if (isSelect)
        {
            this.data.idShield = idShield;
            SetData();
        }
        
    }

    public void ChangeFullSkin(DataFullSkin data, bool value)
    {
        this.bodySkin.GetComponent<SkinnedMeshRenderer>().material = data.body[0];
        panSkin.GetComponent<SkinnedMeshRenderer>().material = data.pant[0];

        playerShiled.GetComponent<SetDisplayItem>().SetActive(data.IdShield);
        playerHat.GetComponent<SetDisplayItem>().SetActive(data.IdHat);
        playerBack.GetComponent<SetDisplayItem>().SetActive(data.IdBack);

        if (value)
        {
            this.data.idShield = data.IdShield;
            this.data.idBack = data.IdBack;
            this.data.idHat = data.IdHat;
            this.data.bodyMaterial = data.body[0];
            this.data.pansMaterial = data.pant[0];
        }




    }



    public void SetDataWeapon(Mesh mesh, Material[] mts, int type)
    {
        this.data.meshWeapon = mesh;
        this.data.materials = mts;
       
        this.data.typeWeapon = type;
        SetData();
    }

    public void ResetData()
    {
        this.data.bodyMaterial = bodyPlayerOrigin;
        this.data.pansMaterial = pantPlayerOrign;
        this.data.idBack = -1;
        this.data.idHat = -1;
        this.data.idShield = -1;

        SetData();
    }
    

    
}