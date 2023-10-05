using Unity.VisualScripting;
using UnityEngine;

public class BrushMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public float BrushSpeed = 80f;
    [SerializeField] private LayerMask whatIsGround;
    private PlayerInput _input;
    
    public bool isBrushGrounded;
    
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();

    }

    void Update()
    {

        if (_input.brush > 0)
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            _rigidbody2D.velocity = transform.forward * BrushSpeed;
        }

        
        if (_input.brush < 0)
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            _rigidbody2D.velocity = -transform.forward * BrushSpeed;
        }

        /*
        if (Input.GetKey(KeyCode.DownArrow))
        {
            var rotation = transform.parent.rotation.eulerAngles.z;

            rotation += 1;
            
            transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        }
        */

        isBrushGrounded = GroundedBrush();
        print(isBrushGrounded);
        
    }

    private bool GroundedBrush()
    {
        float offset = .4f;
        
        // Just visuals, no function
        Debug.DrawRay(transform.GetChild(0).position + new Vector3(offset, 0, 0), Vector2.down);
        Debug.DrawRay(transform.GetChild(0).position - new Vector3(offset, 0, 0), Vector2.down);
                
        // Draw raycasts downwards from brushRaycasterPosition, they are drawn with an offset on the x-axis on both sides
        bool hitLeft = Physics2D.Raycast(transform.GetChild(0).position + new Vector3(offset, 0, 0), Vector2.down, 0.5f, whatIsGround);
        bool hitRight = Physics2D.Raycast(transform.GetChild(0).position - new Vector3(offset, 0, 0), Vector2.down, 0.5f, whatIsGround);

        if (hitLeft || hitRight)
            return true;
        else
            return false;
        
        //return Physics2D.Raycast(transform.GetChild(0).position, Vector2.down, 0.5f, whatIsGround);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //isBrushGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //isBrushGrounded = false;
    }
}
