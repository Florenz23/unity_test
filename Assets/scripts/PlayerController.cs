using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (0.0f, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }
}
