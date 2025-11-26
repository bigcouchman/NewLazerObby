using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class Movement : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool cursorLock = true;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float Speed = 6.0f;
    [SerializeField] float crouchSpeed = 3.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground; 

    [SerializeField] private KeyCode crouchKey = KeyCode.C;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3(0,0.5f,0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0,0,0);
    [SerializeField] private bool isCrouching = false;
    [SerializeField] private bool duringCrouchAnimation = false;
    [SerializeField] private bool canCrouch = true;
 
    public float jumpHeight = 6f;
    float velocityY;
    bool isGrounded;
 
    float cameraCap;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;
    
    CharacterController controller;
    Vector2 currentDir;
    Vector2 currentDirVelocity;
    Vector3 velocity;
    private bool ShouldCrouch => Input.GetKeyDown(crouchKey) && !duringCrouchAnimation && controller.isGrounded;
 
    void Start()
    {
        controller = GetComponent<CharacterController>();
 
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }
 
    void Update()
    {
        UpdateMouse();
        UpdateMove();
        if(canCrouch)
            UpdateCrouch();
    }
 
    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
 
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
 
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
 
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);
 
        playerCamera.localEulerAngles = Vector3.right * cameraCap;
 
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
 
    void UpdateMove()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, controller.height / 2 + 0.2f, ground);
 
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
 
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);
 
        velocityY += gravity * 2f * Time.deltaTime;
        Vector3 velocity;
        if(isCrouching)
            velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * crouchSpeed + Vector3.up * velocityY;
        else 
            velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed + Vector3.up * velocityY;
 
        controller.Move(velocity * Time.deltaTime);
 
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
 
        if(!isGrounded && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }

    void UpdateCrouch()
    {
        if(ShouldCrouch)
        {
            StartCoroutine(CrouchStand());
        }
    }

    private IEnumerator CrouchStand()
    {
        if(isCrouching && Physics.Raycast(playerCamera.transform.position,Vector3.up,1f))
            yield break;
        
        duringCrouchAnimation = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standingHeight : crouchHeight;
        float currentHeight = controller.height;
        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = controller.center;

        while(timeElapsed < timeToCrouch)
        {
            controller.height = Mathf.Lerp(currentHeight,targetHeight,timeElapsed/timeToCrouch);
            controller.center = Vector3.Lerp(currentCenter,targetCenter,timeElapsed/timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        controller.height = targetHeight;
        controller.center = targetCenter;

        isCrouching = !isCrouching;

        duringCrouchAnimation = false;
    }
}