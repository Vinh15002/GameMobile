


using Assets.Scripts.Animation;
using Assets.Scripts.Event;
using Assets.Scripts.Ultils;
using System.Collections;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class Player : Object
{

    [SerializeField]
    private GameObject effectLevelUp;


    [SerializeField] private GameObject playerHat;
    [SerializeField] private GameObject playerShiled;
   


   
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
        yield return new  WaitForSeconds(1f);
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

    public void ChangePants(DataSkinPant data)
    {

        panSkin.GetComponent<SkinnedMeshRenderer>().material = data.materials[0];
    }

    public void ChangeHat(int idHat)
    {
        
        playerHat.GetComponent<SetDisplayItem>().SetActive(idHat);
    }

    public void ChangeShield(int idShield)
    {
        playerShiled.GetComponent<SetDisplayItem>().SetActive(idShield);
    }
}