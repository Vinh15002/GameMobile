

using Assets.Scripts.Objects;
using Cinemachine;
using UnityEngine;

public class PlayerUI : ObjectUpdateUI
{
    [SerializeField] private CinemachineVirtualCamera camera;


    private float originCamera;
   

    private void Start()
    {
        originCamera = camera.m_Lens.FieldOfView;
        
    }



    public void UpdateCamera(int level)
    {
       
        if (level <= 2)
        {
           
            camera.m_Lens.FieldOfView = originCamera + 2;
            
       
        }
        else if (level < 5)
        {
           
            camera.m_Lens.FieldOfView = originCamera + 5;
        }
        else
        {
           
            camera.m_Lens.FieldOfView = originCamera + 10;
        }
        //camera.m_Lens.FieldOfView =  originCamera + level;

    }







}
