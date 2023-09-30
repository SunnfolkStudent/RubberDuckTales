using UnityEngine;

public class BrushMovement : MonoBehaviour
{
    public Rigidbody2D mRigidbody2D;
    public float moveSpeed;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        mRigidbody2D = GetComponent<Rigidbody2D>();
        //Set the speed of the GameObject
        moveSpeed = 85.0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            mRigidbody2D.velocity = transform.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            mRigidbody2D.velocity = -transform.forward * moveSpeed;
        }
    }
}
