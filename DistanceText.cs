using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{
    void Start()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(-1.2f, -2.5f, Camera.main.nearClipPlane)) + Camera.main.transform.forward;
        transform.position = pos;
    }

    public void SetPopup(int dist)
    {
        GetComponent<TextMeshPro>().text = dist + " ft.";
    }
}
