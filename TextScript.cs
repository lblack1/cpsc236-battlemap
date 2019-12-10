using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(-1.3f, -3.6f, Camera.main.nearClipPlane)) + Camera.main.transform.forward;
        transform.position = pos;
        gameObject.GetComponent<TextMeshPro>().text = Globals.selectedObj.GetComponent<Token>().tokenName +
            "\nHP: " + Globals.selectedObj.GetComponent<Token>().hp +
            "\nInitiative: " + Globals.selectedObj.GetComponent<Token>().initiative;
    }



}
