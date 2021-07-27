using UnityEngine;

public class Units : MonoBehaviour
{
    private Animator animator;

    private readonly int _moveSpeed = 2;
    private StartOptions startOptions;


    private void Start()
    {
        startOptions = FindObjectOfType<StartOptions>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (startOptions.IsRunning)
        {
            animator.SetBool("IsRunning", true);
            transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
        }
    }


    private void OnTriggerEnter()
    {
        startOptions.units.Remove(gameObject);
        Destroy(gameObject);
    }
}
