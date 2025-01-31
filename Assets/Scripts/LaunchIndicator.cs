using Unity.Cinemachine;
using UnityEngine;

public class LaunchIndicator : MonoBehaviour
{
    // the variables
    [SerializeField] private CinemachineCamera freeLookCamera;

    [SerializeField] private float offset = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.forward = freeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        // fixing the position of the indicator
        Vector3 ballPosition = transform.parent.position;
        transform.position = ballPosition + freeLookCamera.transform.forward * offset;
        transform.position = new Vector3(transform.position.x, 1, transform.position.y);
        // Debug.Log("arrow position: " + transform.position);
    }
}
