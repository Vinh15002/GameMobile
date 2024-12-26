using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Weapon : MonoBehaviour
    {
       
        [SerializeField]private float speedMovement = 3f;

        public GameObject onwer;
        private const float ANGLE = 15f;
        private Vector3 currentRotate;
        public Vector3 direction = Vector3.zero;
        private Vector3 positonStart;

        public float distanceToDestroy = 2f;


        public bool IsDestroy{
            get {return (transform.position - positonStart).sqrMagnitude > distanceToDestroy;}
        }


        private void Start()
        {
            positonStart= transform.position;
            currentRotate = transform.rotation.eulerAngles;
            
        }

    

        private void FixedUpdate()
        {
            handleRoration();
            handleMovement();
            if(IsDestroy){
                Destroy(gameObject);
            }
        }

        private void handleMovement()
        {
            Vector3 newPosition = direction + transform.position;
            transform.position = Vector3.Lerp(transform.position, newPosition, speedMovement * Time.deltaTime);
        }

        private void handleRoration()
        {
            currentRotate.z += ANGLE;
          

            Quaternion directionRotation = Quaternion.Euler(currentRotate);
            transform.rotation = directionRotation;
        }

        

     

        
    }
}
