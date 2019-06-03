using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeNum : MonoBehaviour
{
    public void GetInputRows(string rows)
    {
        PlayerPrefs.SetString("SizeRows",rows);
        Debug.Log(rows);
    } 
    public void GetInputColumns(string cols)
    {
        PlayerPrefs.SetString("SizeCols",cols);
        Debug.Log(cols);
    } 
}
