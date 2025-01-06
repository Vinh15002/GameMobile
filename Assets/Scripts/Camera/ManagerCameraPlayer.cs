
using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class ManagerCameraPlayer : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera myCam;
    [SerializeField] private float angleOff;
    [SerializeField] private float angleOn;

    [SerializeField] private float speedMoveCam;
    private float angleCurrent = 0;

    public static ManagerCameraPlayer Instance;

    private void Start()
    {
        Instance = this;
    }

    public void SetCamUp()
    {
        StartCoroutine(CamUpCoroutine());
    }

    public void SetCamOff()
    {
        StartCoroutine(CamOffCoroutine());
    }

    private IEnumerator CamOffCoroutine()
    {
        angleCurrent = angleOn;


        while (angleCurrent > angleOn)
        {
            Quaternion rotZ = Quaternion.Euler(angleCurrent, 0, 0);
            myCam.transform.rotation = rotZ;
            angleCurrent -= Time.deltaTime * speedMoveCam;
            yield return null;
        }
    }


    private IEnumerator CamUpCoroutine()
    {
        angleCurrent = angleOff;


        while (angleCurrent < angleOn)
        {
            Quaternion rotZ = Quaternion.Euler(angleCurrent, 0, 0);
            myCam.transform.rotation = rotZ;
            angleCurrent += Time.deltaTime * speedMoveCam;
            yield return null;
        }
    }


    public void SetCamShopSkinOn()
    {
        myCam.transform.rotation = Quaternion.Euler(angleOff,0,0);
        myCam.m_Lens.FieldOfView = 55;
        myCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, -1, 0);
    }

    public void SetCamShopOff()
    {
        myCam.m_Lens.FieldOfView = 100;
        myCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, 0, 0);
    }
}
