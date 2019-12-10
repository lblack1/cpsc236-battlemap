using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;

public class Token : MonoBehaviour
{

    public string tokenName;
    public int hp;
    public int initiative;
    public bool selected;
    public GameObject infoDisplay;
    public GameObject selectionMarker;
    public GameObject distPop;

    public void OnDeselect()
    {
        selected = false;
        Destroy(GameObject.Find("Popup(Clone)"));
        Destroy(GameObject.Find("SelectionMarker(Clone)"));
    }

    public void OnSelect()
    {
        selected = true;
        GameObject.Instantiate(infoDisplay, Camera.main.transform);
        GameObject.Instantiate(selectionMarker, transform).transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void DistPopup(int dist)
    {
        GameObject text = GameObject.Instantiate(distPop, Camera.main.transform);
        text.GetComponent<TextMeshPro>().text = tokenName + "\n" + dist + " ft.";
    }

}
