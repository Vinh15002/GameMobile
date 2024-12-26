
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera;

    [SerializeField]
    private GameObject followObject;


    private Vector3 startPosition;


    private void Start()
    {
        startPosition = targetCamera.transform.position;
    }

    private void FixedUpdate()
    {
        targetCamera.transform.position = startPosition + new Vector3(followObject.transform.position.x, 0f, followObject.transform.position.z);
    }




}
