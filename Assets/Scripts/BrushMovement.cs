using UnityEngine;

public class BrushMovement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody2D;
    float m_Speed;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        //Set the speed of the GameObject
        m_Speed = 85.0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody2D.velocity = transform.forward * m_Speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody2D.velocity = -transform.forward * m_Speed;
        }
    }
}
