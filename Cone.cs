using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
    public double bobSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = Globals.selectedObj.transform;
        transform.eulerAngles = new Vector3(90f, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + .01f * (float)System.Math.Sin((double)Time.time * bobSpeed), transform.position.z);
    }
}
