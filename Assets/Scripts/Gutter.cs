using UnityEngine;

public class Gutter : MonoBehaviour
{

    private void OnTriggerEnter(Collider triggeredBody) {
        // getting the RigidBody of the bowling ball
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        // store the velocity magnitude before resetting it
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        // it's important to reset the linear AND angular velocity since the ball is rotating on the ground when moving
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        // adding force to the forward direction of the gutter
        // using the cached velocity magnitude to keep it somewhat realistic
        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
