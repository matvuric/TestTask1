using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private StartOptions startOptions;

    private readonly float _moveSpeed = 1.4f;


    private void Start()
    {
        startOptions = FindObjectOfType<StartOptions>();
    }
    private void Update()
    {
        if (startOptions.IsRunning)
        {
            transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
            transform.Translate(_moveSpeed * Time.deltaTime * Vector3.up);
        }
    }
}
