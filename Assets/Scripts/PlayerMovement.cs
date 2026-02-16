using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    float Defualthight;
    bool ISGrounded;
    Rigidbody objectrb;
    CapsuleCollider col;
    Rigidbody grabbedRB;
    bool isHolding = false;
    bool iscrouching;
    bool isRunning;
    List<MeshRenderer> hiddenObjects = new List<MeshRenderer>();
    AudioSource Source;
    Animator anim;
    bool isFootPlaying = false;
    String nameOfGround;
    string lastGroundName;
    [SerializeField] SoundManager _SoundManage;
    [Header("Playerattributes")]
    [SerializeField] Transform cam;
    [SerializeField] Transform Hand;
    [SerializeField] Transform RayPos;
    [SerializeField] Transform player;



    [Space(4)]
    [Header("PlayerStatus")]
    [SerializeField] float moveSpeed = 6;
    [SerializeField] float rotateSpeed = 15;
    [SerializeField] float JumpForce;
    [SerializeField] float Range;
    [SerializeField] float CheckGroundRange;
    [SerializeField] float crouchSpeed = 8f;


    [Space(4)]
    [Header("Keys")]
    [SerializeField] KeyCode _Crouch;
    [SerializeField] KeyCode _Jump;
    [SerializeField] KeyCode _Push;
    [SerializeField] KeyCode _Grab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        Source = GetComponent<AudioSource>();

        rb.freezeRotation = true;
        Defualthight = col.height;

    }
    private void Start()
    {
        _SoundManage = SoundManager.Instance;

    }
    private void FixedUpdate()
    {
        move();

    }
    private void Update()
    {
        checkGround();
        HandleCrouch();
        push();
        jump();
        GrabEvent();
       checkCamera();

    }
    
    private void push()
    {
        RaycastHit hit;
        if (Input.GetKey(_Push)||Input.GetButton("Fire1"))
        {
            anim.SetTrigger("push");
            if (Physics.Raycast(RayPos.position, transform.forward, out hit, Range))
            {
                if (hit.collider.CompareTag("Object"))
                {
                    objectrb = hit.collider.GetComponent<Rigidbody>();

                    if (objectrb != null)
                    {
                        objectrb.mass = 1;
                    }
                }
            }
        }
        else
        {
            if (objectrb != null)
            {
                objectrb.mass = 20;
            }
        }
    }
    private void move() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward = cam.forward; camForward.y = 0; camForward.Normalize();
        Vector3 camRight = cam.right; camRight.y = 0; camRight.Normalize();


        Vector3 moveDir = camForward * v + camRight * h;
        bool isMoving = moveDir.sqrMagnitude > 0.01f;

        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftShift)||Input.GetButton("Debug Next"))
        {
            isRunning=true;
            moveSpeed=5;
        }
        else
        {
            isRunning=false;
            moveSpeed=3;
        }

        if (isMoving)
        {
            if (nameOfGround != lastGroundName)
            {
                if (lastGroundName == "wood")
                    _SoundManage.PlaySoundclip(_SoundManage.WalkOnWoodFloor, false, Source);
                else if (lastGroundName == "water")
                    _SoundManage.PlaySoundclip(_SoundManage.WalkOnWater, false, Source);



                if (nameOfGround == "wood")
                    _SoundManage.PlaySoundclip(_SoundManage.WalkOnWoodFloor, true, Source);
                else if (nameOfGround == "water")
                    _SoundManage.PlaySoundclip(_SoundManage.WalkOnWater, true, Source);

                lastGroundName = nameOfGround; 
            }
            else
            {
                if (!isFootPlaying)
                {
                    if (nameOfGround == "wood")
                        _SoundManage.PlaySoundclip(_SoundManage.WalkOnWoodFloor, true, Source);
                    else if (nameOfGround == "water")
                        _SoundManage.PlaySoundclip(_SoundManage.WalkOnWater, true, Source);

                    isFootPlaying = true;
                }
            }
        }
        else
        {
            if (isFootPlaying)
            {
                if (nameOfGround == "wood")
                    _SoundManage.PlaySoundclip(_SoundManage.WalkOnWoodFloor, false, Source);
                else if (nameOfGround == "water")
                    _SoundManage.PlaySoundclip(_SoundManage.WalkOnWater, false, Source);

                isFootPlaying = false;
            }
        }




        if (isMoving)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, rotateSpeed * Time.fixedDeltaTime));
        }

        if (isMoving && iscrouching)
        {

            WalkAnimation("walkwithcrouch", true);
            WalkAnimation("walk", false);
        }
        //Run
        else if (isMoving&&!isRunning)
        {
            WalkAnimation("walk", true);
            WalkAnimation("walkwithcrouch", false);
        }
       


           else if (isRunning&&isMoving)
        {
            WalkAnimation("walk", false);
            WalkAnimation("walkwithcrouch", false);
                        WalkAnimation("Run", true);
                        

        }
        else
        {
   WalkAnimation("Run", false);
            WalkAnimation("walk", false);
            WalkAnimation("walkwithcrouch", false);
        }
    }
    private void HandleCrouch()
    {
      
      bool isCrouching = Input.GetKey(_Crouch) || Input.GetButton("Fire2");

float targetHeight = isCrouching ? Defualthight / 2 : Defualthight;

        float currentHeight = col.height;
        anim.SetFloat("crouch", currentHeight);

        col.height = Mathf.Lerp(currentHeight, targetHeight, Time.deltaTime * crouchSpeed);

        col.center = new Vector3(
            col.center.x,
            col.height / 2f,
            col.center.z
        );
        if (currentHeight > 1.1)
        {
            iscrouching = false;
           
        }
        else
        {
            iscrouching = true;
        }
    }

    
 
    private void jump()
    {
        bool jumpPressed = Input.GetKeyDown(_Jump) || Input.GetButtonDown("Jump");

        if (jumpPressed && ISGrounded)
        {
            anim.SetTrigger("jump");
            _SoundManage.PlaySoundclipOneShot(_SoundManage.Jump, Source);

            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void StopMoving()
    {
     

    moveSpeed = 0;
    rotateSpeed = 0;
    }
    private void resetMoving()
    { 

    moveSpeed = 3;
    rotateSpeed = 6;

    }
    private void GrabEvent()
    {
        if (Input.GetKeyDown(_Grab)||Input.GetButtonDown("Fire3"))
        {
            StopMoving();
            anim.SetTrigger("grab");
        }
    }
    public void Grab()
{

        resetMoving();
            if (isHolding)
         {
            ReleaseObject();
            return;
         }

            Collider[] col = Physics.OverlapSphere(transform.position, Range);
                foreach (var Led in col) {
                if (Led.CompareTag("LED"))
                {
                    grabbedRB = Led.GetComponent<Rigidbody>();
                    if (grabbedRB != null)
                    {
                        grabbedRB.linearVelocity = Vector3.zero;
                        grabbedRB.angularVelocity = Vector3.zero;
                        grabbedRB.isKinematic = true;
                        grabbedRB.transform.SetParent(Hand);
                        grabbedRB.transform.localPosition = Vector3.zero;

                        isHolding = true;
                        break;

                }
            }
            }
        }
    
    
    private void ReleaseObject()
{
    if (grabbedRB != null)
    {

            grabbedRB.transform.SetParent(null);
        grabbedRB.isKinematic = false;

        grabbedRB = null;
    }

    isHolding = false;
}
    private void checkGround()
    {
        RaycastHit hit;

        Vector3 origin = transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(origin, Vector3.down, out hit, CheckGroundRange))
        {
            ISGrounded =
    hit.collider.CompareTag("Ground") ||
    hit.collider.CompareTag("Object") ||
    hit.collider.CompareTag("LED");

             nameOfGround = LayerMask.LayerToName(hit.collider.gameObject.layer);
        }
        else
        {
            ISGrounded = false;
        }
    }
    private void checkCamera()
{
    RaycastHit hit;

    Vector3 camPos = Camera.main.transform.position;
    Vector3 direction = player.position - camPos;
float distance = Vector3.Distance(camPos, player.position) + 5f;

    Ray ray = new Ray(camPos, direction);

    for (int i = 0; i < hiddenObjects.Count; i++)
    {
        if (hiddenObjects[i] == null) continue;

        foreach (Material mat in hiddenObjects[i].materials)
        {
            Color c = mat.color;
            c.a = Mathf.Lerp(c.a, 1f, Time.deltaTime * 5f);
            mat.color = c;
        }
    }

    if (Physics.Raycast(ray, out hit, distance))
    {
        if (!hit.collider.CompareTag("Player"))
        {
            MeshRenderer mr = hit.collider.GetComponent<MeshRenderer>();

            if (mr != null)
            {
                foreach (Material mat in mr.materials)
                {
                    Color c = mat.color;
                    c.a = Mathf.Lerp(c.a, 0.02f, Time.deltaTime * 5f);
                    mat.color = c;
                }

                if (!hiddenObjects.Contains(mr))
                    hiddenObjects.Add(mr);
            }
        }
    }
}

    private void ResetHiddenObjects()
    {
        for (int i = 0; i < hiddenObjects.Count; i++)
        {
            if (hiddenObjects[i] != null)
                hiddenObjects[i].enabled = true;
        }

        hiddenObjects.Clear();
    }

  

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            RayPos.position,
            RayPos.position + transform.forward * Range
        );

        Gizmos.DrawLine(
          transform.position,
          transform.position + Vector3.down * CheckGroundRange
      );
    }
    private void WalkAnimation(string name ,bool IsWork)
    {
        anim.SetBool(name, IsWork);
    }
}
