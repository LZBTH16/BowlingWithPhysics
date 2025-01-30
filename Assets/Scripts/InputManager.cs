using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    // the Unity event for the player
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    // the Unity event for when "Space" is pressed
    public UnityEvent OnSpacePressed = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnSpacePressed?.Invoke();
        }
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A)){
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D)) {
            input += Vector2.right;
        }
        OnMove?.Invoke(input);
    }
}
