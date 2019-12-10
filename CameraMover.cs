using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float panFrac = 6f;
    public float rotSpeed = 3.5f;
    private float X;
    private float Y;
    private Vector3 dragOrigin;

    void Update()
    {

        if (!Globals.editing)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift) && Globals.moveCamera)
            {
                panFrac /= 2f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && Globals.moveCamera)
            {
                panFrac *= 2f;
            }

            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.UpArrow) && Globals.moveCamera)
            {
                transform.Translate(Vector3.up / panFrac);
            }
            else if (Input.GetKey(KeyCode.UpArrow) && Globals.moveCamera)
            {
                Vector3 move = Camera.main.transform.forward / panFrac;
                move.Set(move.x, 0, move.z);
                transform.position += move;
            }

            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.DownArrow) && Globals.moveCamera)
            {
                transform.Translate(Vector3.down / panFrac);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && Globals.moveCamera)
            {
                Vector3 move = Camera.main.transform.forward / panFrac * -1;
                move.Set(move.x, 0, move.z);
                transform.position += move;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && Globals.moveCamera)
            {
                Vector3 move = Camera.main.transform.right / panFrac * -1;
                move.Set(move.x, 0, move.z);
                transform.position += move;
            }

            if (Input.GetKey(KeyCode.RightArrow) && Globals.moveCamera)
            {
                Vector3 move = Camera.main.transform.right / panFrac;
                move.Set(move.x, 0, move.z);
                transform.position += move;
            }

            if (Input.GetMouseButton(1) && Globals.moveCamera)
            {
                transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * rotSpeed, -Input.GetAxis("Mouse X") * rotSpeed, 0));
                X = transform.rotation.eulerAngles.x;
                Y = transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(X, Y, 0);
            }
        }
    }
}
