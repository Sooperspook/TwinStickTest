using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D plRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

   
	// Use this for initialization
	void Start () {

        plRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // This is weird. 
        moveInput = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Using up or down instead of back here, the ray does not seem to appear at all
        // Using back or forward, the ray seems to go straight down the z axis and not originate at the camera
        Plane playField = new Plane(Vector3.back, Vector3.zero); 
        float rayLength;

        if (playField.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
            // For some reason the player is flat on the z axis and doesn't interacti with the enemies or bullets, 
            // if LookAt is active
            transform.LookAt(pointToLook);
        }
	}

    void FixedUpdate()
    {

        plRigidbody.velocity = moveVelocity;
    }
}
