using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void Begin()
    {
        SceneManager.LoadScene("MapScene");
    }

    // Update is called once per frame
    public void Reneg()
    {
        Application.Quit();
    }

    public void Continue()
    {
        if (File.Exists("MapState.bttl"))
        {
            Globals.loadIn = true;
        }
        SceneManager.LoadScene("MapScene");

    }
}
