using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOptions : MonoBehaviour
{
    [SerializeField] private GameObject unit;

    public List<GameObject> units = new List<GameObject>();

    public bool IsRunning = false;

    private void Start()
    {
        float _posX = -1f;

        for (int i = 0; i < 5; i++)
        {
            var unt = Instantiate(unit, new Vector3(_posX, 0.25f, 0), Quaternion.identity);
            units.Add(unt);
            _posX += 0.5f;
        }
    }

    private void Update()
    {
        if (units.Count == 0)
        {
            IsRunning = false;
        }
    }

    internal void Redirect(List<Vector3> positions, int width, int height)
    {
        int divider = 0;

        if (units.Count != 0)
        {
            divider = positions.Count / units.Count;
        }

        for (int i = 0; i < units.Count; i++)
        {
            if ((positions[i * divider].x > width) && (positions[i * divider].y > height))
            {
                units[i].transform.position = new Vector3(positions[i * divider].x / 400f, 0, units[i].transform.position.z + positions[i * divider].y / 400f);
            }
            else if ((positions[i * divider].x <= width) && (positions[i * divider].y > height))
            {
                units[i].transform.position = new Vector3((positions[i * divider].x - 500) / 400f, 0, units[i].transform.position.z + positions[i * divider].y / 400f);
            }
            else if ((positions[i * divider].x > width) && (positions[i * divider].y <= height))
            {
                units[i].transform.position = new Vector3(positions[i * divider].x / 400f, 0, units[i].transform.position.z + (positions[i * divider].y - 250) / 400f);
            }
            else if ((positions[i * divider].x <= width) && (positions[i * divider].y <= height))
            {
                units[i].transform.position = new Vector3((positions[i * divider].x - 500) / 400f, 0, units[i].transform.position.z + (positions[i * divider].y - 250)/ 400f);
            }
        }
    }
}
