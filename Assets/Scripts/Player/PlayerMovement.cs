using Assets.Scripts.Animation;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class PlayerMovement : ObjectMovement
{
    [SerializeField] private VariableJoystick joystick;

   

    private void FixedUpdate()
    {
        handleMovement();

       
    }

    private void handleMovement()
    {
        movementDirection = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y); 
        
        if(IsMoving)
        {
            animator.SetBool(AnimationString.IsIdle, false);
            handleRoration(movementDirection);
            Vector3 newPosition = movementDirection + transform.position;
            
            transform.position = Vector3.Lerp(transform.position, newPosition, speedMovement * Time.deltaTime);
        }
        else
        {
            animator.SetBool(AnimationString.IsIdle, true);
        }
    }


    
}
