using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        else
        {
            ray = new Ray(transform.position, transform.up);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
