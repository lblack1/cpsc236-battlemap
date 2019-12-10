using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class InitiativeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SortedDictionary<int, GameObject> sortedToks = new SortedDictionary<int, GameObject>(new DupeComparer<int>());
        foreach(Transform obj in GameObject.Find("TokenCollection").transform)
        {
            sortedToks.Add(obj.gameObject.GetComponent<Token>().initiative, obj.gameObject);
        }
        string temp = "Initiative Order\n";
        foreach (KeyValuePair<int, GameObject> kvp in sortedToks.Reverse())
        {
            temp += kvp.Value.GetComponent<Token>().initiative + " - " + kvp.Value.GetComponent<Token>().tokenName + "\n";
        }
        GetComponent<TextMeshProUGUI>().text = temp;
        transform.position = Camera.main.ViewportToScreenPoint(new Vector3(.1f, .9f, Camera.main.nearClipPlane));
    }

    // Update is called once per frame
    public void Rewrite()
    {
        SortedDictionary<int, GameObject> sortedToks = new SortedDictionary<int, GameObject>(new DupeComparer<int>());
        foreach (Transform obj in GameObject.Find("TokenCollection").transform)
        {
            sortedToks.Add(obj.gameObject.GetComponent<Token>().initiative, obj.gameObject);
        }
        string temp = "Initiative Order\n";
        foreach (KeyValuePair<int, GameObject> kvp in sortedToks.Reverse())
        {
            temp += kvp.Value.GetComponent<Token>().initiative + " - " + kvp.Value.GetComponent<Token>().tokenName + "\n";
        }
        GetComponent<TextMeshProUGUI>().text = temp;
    }
}

public class DupeComparer<TKey> : IComparer<TKey> where TKey : IComparable
{
    public int Compare(TKey x, TKey y)
    {
        int res = x.CompareTo(y);

        if (res == 0)
            return 1;
        else
            return res;
    }
}