using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public float posY;
    public GameObject player;
    public GameObject enemy;

    private void Start()
    {
        transform.position = Camera.main.ViewportToScreenPoint(new Vector3(.9f, .9f-posY/20f, Camera.main.nearClipPlane));
    }

    public void Edit()
    {
        if (Globals.selectedObj && !Globals.editing)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Okay";
            if (Globals.selectedObj.gameObject.tag == "Token")
            {
                Globals.editing = true;
                GameObject.Find("NDisp").GetComponent<Text>().text = "Name:";
                GameObject.Find("HPDisp").GetComponent<Text>().text = "HP:";
                GameObject.Find("IniDisp").GetComponent<Text>().text = "Initiative:";
                GameObject.Find("NIn").GetComponent<InputField>().interactable = true;
                GameObject.Find("HPIn").GetComponent<InputField>().interactable = true;
                GameObject.Find("IniIn").GetComponent<InputField>().interactable = true;
                GameObject.Find("NIn").GetComponent<InputField>().ActivateInputField();
                GameObject.Find("HPIn").GetComponent<InputField>().ActivateInputField();
                GameObject.Find("IniIn").GetComponent<InputField>().ActivateInputField();
                GameObject.Find("NIn").GetComponent<InputField>().text = Globals.selectedObj.GetComponent<Token>().tokenName;
                GameObject.Find("HPIn").GetComponent<InputField>().text = Globals.selectedObj.GetComponent<Token>().hp.ToString();
                GameObject.Find("IniIn").GetComponent<InputField>().text = Globals.selectedObj.GetComponent<Token>().initiative.ToString();
                
            }
        }
        else if (Globals.editing)
        {
            int tempHP = Globals.selectedObj.GetComponent<Token>().hp;
            int tempIni = Globals.selectedObj.GetComponent<Token>().initiative;
            GetComponentInChildren<TextMeshProUGUI>().text = "Edit";
            GameObject.Find("NDisp").GetComponent<Text>().text = "";
            GameObject.Find("HPDisp").GetComponent<Text>().text = "";
            GameObject.Find("IniDisp").GetComponent<Text>().text = "";
            Globals.selectedObj.GetComponent<Token>().tokenName = GameObject.Find("NIn").GetComponent<InputField>().text;
            if (!int.TryParse(GameObject.Find("HPIn").GetComponent<InputField>().text, out Globals.selectedObj.GetComponent<Token>().hp))
                Globals.selectedObj.GetComponent<Token>().hp = tempHP;
            if (!int.TryParse(GameObject.Find("IniIn").GetComponent<InputField>().text, out Globals.selectedObj.GetComponent<Token>().initiative))
                Globals.selectedObj.GetComponent<Token>().initiative = tempIni;
            GameObject.Find("NIn").GetComponent<InputField>().text = "";
            GameObject.Find("HPIn").GetComponent<InputField>().text = "";
            GameObject.Find("IniIn").GetComponent<InputField>().text = "";
            GameObject.Find("NIn").GetComponent<InputField>().interactable = false;
            GameObject.Find("HPIn").GetComponent<InputField>().interactable = false;
            GameObject.Find("IniIn").GetComponent<InputField>().interactable = false;
            GameObject.Find("NIn").GetComponent<InputField>().DeactivateInputField();
            GameObject.Find("HPIn").GetComponent<InputField>().DeactivateInputField();
            GameObject.Find("IniIn").GetComponent<InputField>().DeactivateInputField();
            Globals.selectedObj.GetComponent<Token>().OnDeselect();
            Globals.selectedObj.GetComponent<Token>().OnSelect();
            Globals.editing = false;
            GameObject.Find("InitiativeOrder").GetComponent<InitiativeText>().Rewrite();
        }
    }



    public void Exit()
    {
        if (File.Exists("MapState.bttl"))
        {
            File.Delete("MapState.bttl");
        }
        FileStream mapState = File.Open("MapState.bttl", FileMode.Create);
        StreamWriter stateWriter = new StreamWriter(mapState);
        GameObject[] tokens = GameObject.FindGameObjectsWithTag("Token");
        foreach (GameObject obj in tokens)
        {
            stateWriter.WriteLine(obj.name);
            stateWriter.WriteLine(obj.GetComponent<Token>().tokenName);
            stateWriter.WriteLine(obj.GetComponent<Token>().hp);
            stateWriter.WriteLine(obj.GetComponent<Token>().initiative);
            stateWriter.WriteLine(obj.transform.position.x);
            stateWriter.WriteLine(obj.transform.position.z);
        }
        stateWriter.Close();
        mapState.Close();
        Application.Quit();
    }


    public void NewPlayer()
    {
        GameObject obj = GameObject.Instantiate(player, new Vector3(15, 0, 15), new Quaternion(0, 0, 0, 0));
        obj.tag = "Token";
        obj.transform.parent = GameObject.Find("TokenCollection").transform;
    }

    public void NewEnemy()
    {
        GameObject obj = GameObject.Instantiate(enemy, new Vector3(15, 0, 15), new Quaternion(0, 0, 0, 0));
        obj.tag = "Token";
        obj.transform.parent = GameObject.Find("TokenCollection").transform;
        GameObject.Find("InitiativeOrder").GetComponent<InitiativeText>().Rewrite();
    }

    public void Delete()
    {
        if (Globals.selectedObj)
        {
            Globals.selectedObj.GetComponent<Token>().OnDeselect();
            Destroy(Globals.selectedObj);
            Globals.selectedObj = null;
            GameObject.Find("InitiativeOrder").GetComponent<InitiativeText>().Rewrite();
        }
    }
}
