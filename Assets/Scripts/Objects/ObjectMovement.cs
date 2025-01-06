


using UnityEngine;

public class ObjectMovement: MonoBehaviour{
    [SerializeField] protected float speedMovement;
    [SerializeField] protected float speedRotation;

    protected Animator animator;
    [HideInInspector]public Vector3 movementDirection;
    public bool IsMoving
    {
        get { return movementDirection.magnitude > 0; }
    }

    private void OnEnable() {
        animator = GetComponent<Animator>();
    }

   

    public void handleRoration(Vector3 direction)
    {
        Vector3 targetDirection = Vector3.RotateTowards(transform.forward, direction, speedRotation*Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }



}