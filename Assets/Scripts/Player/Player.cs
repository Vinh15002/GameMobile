


using System.Collections;
using UnityEngine;

public class Player : Object
{

    [SerializeField]
    private GameObject effectLevelUp;


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
}