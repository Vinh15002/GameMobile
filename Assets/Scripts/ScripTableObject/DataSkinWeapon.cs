using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "DataSkin", menuName = "Data/Weapon/Skin")]
public class DataSkinWeapon : ScriptableObject
{

    public int ID;

    public Sprite image;

    public Material[] materials;

    public bool isLock;
}
