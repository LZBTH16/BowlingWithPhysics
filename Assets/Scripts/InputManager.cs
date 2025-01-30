using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    // the Unity event for when "Space" is pressed
    public UnityEvent OnSpacePressed = new UnityEvent();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnSpacePressed?.Invoke();
        }
    }
}
