using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloorTile : MonoBehaviour
{
    public GameObject distPop;
    public GameObject selectionMarker;
    public void DistPopup(int dist)
    {
        GameObject text = GameObject.Instantiate(distPop, Camera.main.transform);
        text.GetComponent<DistanceText>().SetPopup(dist);
    }
}
