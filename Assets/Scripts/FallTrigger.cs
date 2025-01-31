using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    // adding the variables
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;

    private void OnTriggerEnter(Collider triggeredObject) {
        // can use CompareTag() to compare the collided object's tag to a string
        if (triggeredObject.CompareTag("Ground") && !isPinFallen) {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} has fallen");
            // using $"" is C#'s string formatting
        }
        
    }
}
