
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Data/Weapon/DataWeapon")]
public class DataWeapon : ScriptableObject
{
    public int ID;

    public string Name;

    public GameObject prefab;

    public List<DataSkinWeapon> skins;

    public int currentskin;

    public int gold;

    public bool wasBought;

}

