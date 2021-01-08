using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
    
public class RootMotionScript : MonoBehaviour {

    public Animator animator;
    public CharacterController controller;
    public Transform cam;

    public float animSpeed;
    private float horizontal;
    private float vertical;
    private float targetAngle;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Vector3 direction;
    private Vector3 moveDir;

    void OnAnimatorMove()
    {       
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized; 
        animSpeed = animator.GetFloat("speed");

        if (animSpeed > 0)
        {                
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * animSpeed * Time.deltaTime);
        }
        
        else
            return;
    }
}