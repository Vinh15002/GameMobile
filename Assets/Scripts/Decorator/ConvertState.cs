using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertState : MonoBehaviour
{
    [SerializeField]
    private Material materialIn;
    [SerializeField]
    private Material materialOut;

    private MeshRenderer meshRenderer;

    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    public void SetIn(){
        meshRenderer.material = materialOut;
    }
    public void SetOut(){
        meshRenderer.material = materialIn;
    }
}
