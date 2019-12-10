using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MapController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject floorTile;

    // Start is called before the first frame update
    void Start()
    {
        if (Globals.loadIn)
        {

            FileStream fs = File.Open("MapState.bttl", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() >= 0)
            {
                string temp = sr.ReadLine();
                GameObject obj = GameObject.Find(temp);
                if (!obj)
                {
                    if (temp.Contains("Magician"))
                    {
                        obj = GameObject.Instantiate(player, GameObject.Find("TokenCollection").transform);
                    } else
                    {
                        obj = GameObject.Instantiate(enemy, GameObject.Find("TokenCollection").transform);
                    }
                }
                Token tok = obj.GetComponent<Token>();
                tok.tokenName = sr.ReadLine();
                tok.hp = int.Parse(sr.ReadLine());
                tok.initiative = int.Parse(sr.ReadLine());
                int x = int.Parse(sr.ReadLine());
                int z = int.Parse(sr.ReadLine());
                obj.transform.position = new Vector3(x, 0, z);
            }

        }

        GameObject floorPile = new GameObject();
        floorPile.name = "FloorPile";
        for (int i = 0; i < 30; ++i)
        {
            for (int j = 0; j < 30; ++j)
            {
                GameObject temp = GameObject.Instantiate(floorTile, new Vector3(i, 0, j), new Quaternion(0, 0, 0, 0));
                temp.transform.Rotate(90f, 0f, 0f);
                temp.transform.SetParent(floorPile.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
