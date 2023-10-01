using UnityEngine;

public class BrushMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public float moveSpeed;
    [SerializeField] private LayerMask whatIsGround;

    public bool isBrushGrounded;
    
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //Set the speed of the GameObject
        moveSpeed = 200.0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            _rigidbody2D.velocity = transform.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            _rigidbody2D.velocity = -transform.forward * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isBrushGrounded = true;
        Debug.Log("IsBrushGrounded");
        print("Grounded");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isBrushGrounded = false;
        Debug.Log("BrushIsNOTGrounded");
        print("NOTGrounded");
    }

}
