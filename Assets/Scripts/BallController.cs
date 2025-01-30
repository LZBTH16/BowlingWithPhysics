using UnityEngine;

public class BallController : MonoBehaviour
{
    // the variables for use
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    private Rigidbody ballRB;
    private bool isBallLaunched;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // getting a reference to the RigidBody
        ballRB = GetComponent<Rigidbody>();

        // add a listener for the OnSpacePressed event
        // when the space key is pressed, the LaunchBall method will be called
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    // the LaunchBall method
    private void LaunchBall() {
        // if the ball is launched, do nothing (so that the user cannot launch it multiple times in a row)
        if (isBallLaunched) return;
        // if the ball is not launched, set to true & launch the ball
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
