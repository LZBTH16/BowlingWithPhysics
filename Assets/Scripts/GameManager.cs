using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    // the variables
    [SerializeField] private float score = 0;

    // reference to the ballController
    [SerializeField] private BallController ball;
    // reference to the pin collection prefab
    [SerializeField] private GameObject pinCollection;
    // reference to an empty GameObject that'll spawn the pin collection prefab
    [SerializeField] private Transform pinAnchor;
    // reference to InputManager
    [SerializeField] private InputManager inputManager;

    // the score displayed in the UI
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;
    private GameObject pinObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // add the HandleReset function as a listener to the OnResetPressedEvent
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void HandleReset() {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins() {
        // ensure all previous pins are destroyed
        if(pinObjects) {
            foreach (Transform child in pinObjects.transform) {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        // add in new pins
        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);
        Debug.Log($"Number of pins in new collection: {pinObjects.transform.childCount}");

        // add IncrementScore as a listener to the OnPinFall event each set of new pins
        // pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        pins = pinObjects.GetComponentsInChildren<FallTrigger>();
        Debug.Log($"New pins set: {pins.Length}");
        foreach (FallTrigger pin in pins) {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore() {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
