using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{

    int CalcDist(float deltaX, float deltaZ)
    {
        float dist = (float)System.Math.Sqrt(System.Math.Pow(deltaX, 2) + System.Math.Pow(deltaZ, 2));
        return (int)System.Math.Round(dist) * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Globals.editing)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Destroy(GameObject.Find("DistancePopup(Clone)"));
                if (hit.transform.gameObject.tag == "Tile" && Globals.selectedObj)
                {

                    float xDest = hit.transform.position.x;
                    float zDest = hit.transform.position.z;

                    float xPrime = Globals.selectedObj.transform.position.x;
                    float zPrime = Globals.selectedObj.transform.position.z;

                    int dist = CalcDist(xDest - xPrime, zDest - zPrime);
                    hit.transform.gameObject.GetComponent<FloorTile>().DistPopup(dist);

                }
                else if ((hit.transform.gameObject.tag == "Token" && hit.transform.gameObject != Globals.selectedObj) && Globals.selectedObj)
                {
                    float xDest = hit.transform.position.x;
                    float zDest = hit.transform.position.z;

                    float xPrime = Globals.selectedObj.transform.position.x;
                    float zPrime = Globals.selectedObj.transform.position.z;

                    int dist = CalcDist(xDest - xPrime, zDest - zPrime);
                    hit.transform.gameObject.GetComponent<Token>().DistPopup(dist);
                }
            }
            else
            {
                Destroy(GameObject.Find("DistancePopup(Clone)"));
            }

            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    if (hit.transform.gameObject.GetComponent<Token>())
                    {
                        if (Globals.selectedObj == hit.transform.gameObject)
                        {
                            Globals.selectedObj.GetComponent<Token>().OnDeselect();
                            Globals.selectedObj = null;
                        }
                        else
                        {
                            if (Globals.selectedObj)
                            {
                                Globals.selectedObj.GetComponent<Token>().OnDeselect();
                            }
                            Globals.selectedObj = hit.transform.gameObject;
                            Globals.selectedObj.GetComponent<Token>().OnSelect();
                        }
                    }
                    else if (hit.transform.gameObject.tag == "Tile" && Globals.selectedObj)
                    {
                        Globals.selectedObj.transform.position = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
                    }
                }
            }


        }
    }
}
