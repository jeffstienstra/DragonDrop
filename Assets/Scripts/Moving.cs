using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : NetworkBehaviour
{
    public CharacterController _characterController;
    public Transform cam;
    public float playerSpeed = 9.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            Move();
        }

    [Client(RequireOwnership = true)]
        private void Move()
        {
            if(!base.IsOwner)
                return;

        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }
    }
}


// backup of Moving.cs 9-3-22

// using FishNet.Object;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Moving : NetworkBehaviour
// {
//     private CharacterController _characterController;
//     public float playerSpeed = 9.0f;
//     public float RotateSpeed = 125f;
//     public float gravity = -9.81f;
//     public float jumpHeight = 100.0f;
//     public float originalStepOffset = .3f;

//     public Transform groundCheck;
//     public float groundDistance = 0.4f;
//     public LayerMask groundMask;

//     Vector3 velocity;
//     bool isGrounded;

//     private void Awake()
//         {
//             _characterController = GetComponent<CharacterController>();
//         }

//         void Update()
//         {
//             Move();
//         }

//     [Client(RequireOwnership = true)]
//         private void Move()
//         {
//             if(!base.IsOwner)
//                 return;

//         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

//         if(isGrounded && velocity.y < 0)
//             velocity.y = -2f;

//         float Horizontal = Input.GetAxis("Horizontal");
//         float Vertical = Input.GetAxis("Vertical");
//         transform.Rotate(new Vector3(0f, Horizontal * RotateSpeed * Time.deltaTime));

//         // Vector3 move = transform.right * Horizontal + transform.forward * Vertical;
//         Vector3 move = new Vector3(0f, Physics.gravity.y, Vertical) * playerSpeed * Time.deltaTime;
//         move = transform.TransformDirection(move);
//         _characterController.Move(move);

//         if(Input.GetButtonDown("Jump") && isGrounded)
//             velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

//         velocity.y += gravity * Time.deltaTime;

//         _characterController.Move(velocity * Time.deltaTime);
//     }

// }


//     public float RotateSpeed = 150f;
//     public float moveSpeed = 10f;
//     private CharacterController _characterController;
//     // private Animating _animating;

//     public void Awake()
//     {
//         _characterController = GetComponent<CharacterController>();
//         // _animating = GetComponent<Animating>();
//     }

//     private void Update()
//     {
//         Move();
//     }

// [Client(RequireOwnership = true)]
//     private void Move()
//     {
//         if(!base.IsOwner)
//             return;

//         float Horizontal = Input.GetAxis("Horizontal");
//         float Vertical = Input.GetAxis("Vertical");
//         transform.Rotate(new Vector3(0f, Horizontal * RotateSpeed * Time.deltaTime));
//         Vector3 offset = new Vector3(0f, Physics.gravity.y, Vertical) * moveSpeed * Time.deltaTime;
//         offset = transform.TransformDirection(offset);

//         _characterController.Move(offset);

//         // bool isMoving = (Horizontal != 0f || Vertical != 0f);
//         // _animating.SetMoving(isMoving);
//         // if (Input.GetKeyDown(KeyCode.Space))
//         //     _animating.Jump();
//     }
// }
