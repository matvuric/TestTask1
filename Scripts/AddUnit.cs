using UnityEngine;

public class AddUnit : MonoBehaviour
{
    [SerializeField] private GameObject unit;

    private StartOptions startOptions;

    private void Start()
    {
        startOptions = FindObjectOfType<StartOptions>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var unt = Instantiate(unit, transform.position, Quaternion.identity);
        startOptions.units.Add(unt);
        Destroy(gameObject);
    }
}
