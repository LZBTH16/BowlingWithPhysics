using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // the variables
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // find all objects of type FallTrigger
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in pins) {
            pin.OnPillFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore() {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
