using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject BrushRaycaster;

    [Header("Movement")] 
    public float moveSpeed = 5f;
    private Vector2 _desiredVelocity;
    public float playerFallSpeed = 0.2f;

    [Header("CoyoteTime")] 
    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;

    [Header("Acceleration")] 
    public float accelerationTime = 0.10f;
    public float groundFriction = 0.01f;
    public float airFriction = 0.005f;

    [Header("isGrounded")] 
    public LayerMask whatIsGround;
    public LayerMask whatIsBrush;

    [Header("Components")] 
    public Rigidbody2D _rigidbody2D;
    public PlayerInput _input;

    [Header("Brush")] 
    public BrushMovement _brushMovement;
    public float BrushRotationSpeed;

    [Header("Audio")] 
    public AudioManager audioManager;
    public AudioSource audioSource;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        BrushRaycaster = GameObject.Find("BrushRaycaster");
        audioManager = GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _desiredVelocity = _rigidbody2D.velocity;

        if (IsPlayerGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= 1 * Time.deltaTime;
        }

        _rigidbody2D.velocity = _desiredVelocity;
    }


    private bool ducking;

    private void FixedUpdate()
    {
        bool changeable = _input.lift == 0;

        if (changeable)
        {
            if (_brushMovement.transform.rotation.eulerAngles.z <= 180)
            {
                ducking = true;
                print("Yes");
            }
            else
            {
                ducking = false;
                print("NOOOO");
            }
        }

        if (_brushMovement.isBrushGrounded && _input.lift != 0)
        {
            Vector2 direction = BrushRaycaster.transform.position - transform.position;

            
            if (ducking ? _brushMovement.transform.rotation.eulerAngles.z <= 160 : _brushMovement.transform.rotation.eulerAngles.z > 200)
            {
                _desiredVelocity = Quaternion.Euler(0, 0, (ducking ? -1 : 1) * 90) * direction * BrushRotationSpeed;
            }
            
            //_desiredVelocity = new Vector2(_rigidbody2D.velocity.x, 1);

        }
        else if (_input.moveDirection != 0) // != "not"
        {
            _desiredVelocity.x =
                Mathf.Lerp(_desiredVelocity.x, moveSpeed * _input.moveDirection,
                    accelerationTime); // important to multiply moveSpeed with moveDirection!
        }
        else
        {
            _desiredVelocity.x = Mathf.Lerp(
                _desiredVelocity.x, 0f,
                IsPlayerGrounded()
                    ? groundFriction
                    : airFriction); // "?" = If statement, with ":" separating true from false
        }
        _rigidbody2D.velocity = _desiredVelocity;
    }
    
    public bool IsPlayerGrounded()
    {
        return PlayerIsGrounded();
    }
    
    private bool PlayerIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.6f, whatIsGround);
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = _rigidbody2D.velocity.magnitude;

        if (!(speed > playerFallSpeed)) return;
        if (collision.gameObject.CompareTag("Brush")) return;
    }

    /* public class BallCollider : MonoBehaviour
     {
         private Rigidbody2D _rigidbody2D;
         public float speedToDestroyGameObject = 10;

         private void Start()
         {
             _rigidbody2D = GetComponent<Rigidbody2D>();
         }

         private void OnCollisionEnter2D(Collision2D collision)
         {
             var speed = _rigidbody2D.velocity.magnitude;

             if (!(speed > speedToDestroyGameObject)) return;
             if (collision.gameObject.CompareTag("Player"))return;

             Destroy(collision.gameObject);

             Debug.Log("Destroyed Object: " + collision.collider.name + ". Speed: " + speed);
         }
     }
 }*/
}