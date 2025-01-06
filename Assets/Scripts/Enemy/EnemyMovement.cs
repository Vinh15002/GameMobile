

using Assets.Scripts.Animation;
using UnityEngine;

public class EnemyMovement : ObjectMovement
{
    [SerializeField]
    private float timeToMove=2f;

    private float _timeToMove = 0f;

    [SerializeField]
    private LayerMask wallLayer;

    private const float DISTANCE_CHECK = 3f;


    private void FixedUpdate() {
        
        handleMovement();
        checkWall();
        Movement();
        
    }

    private void handleMovement()
    {
        _timeToMove += Time.deltaTime;
        if(_timeToMove > timeToMove){
            int random = Random.Range(1,10);
            if(random <= 7){
                RandomMovement();
            }
            else DontMovement();
            _timeToMove = 0;
        }
    }
    private void checkWall()
    {
        Vector3 positionCheck = transform.position;
        positionCheck.y = 2f;
        RaycastHit ray;
        bool check = Physics.Raycast(positionCheck, transform.TransformDirection(Vector3.forward),out ray, DISTANCE_CHECK, wallLayer);
        if(check){
            
            movementDirection = ray.normal;
            movementDirection.Normalize();
            movementDirection.y = 0;
        }
        

    }



    private void Movement()
    {
         if(IsMoving && speedMovement > 0)
        {
            movementDirection.Normalize();
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

    private void DontMovement()
    {
        movementDirection = Vector3.zero;

    }

    private void RandomMovement()
    {
        float randomDirX = Random.Range(-1f,1f);
        float randomDirZ = Random.Range(-1f,1f);
        movementDirection = new Vector3(randomDirX,0,randomDirZ);
        movementDirection.Normalize();
    }
}
