using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int inventorySize = 20;
    public string[] itemList = new string[inventorySize];

    //Inventory shown on screen and title
    void OnGUI()
    {
        GUI.Box(new Rect(25, 25, 100, 150), inventoryToString());
    }

    public int AddItem(string item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null)
            {
                itemList[i] = item;
                return 1;
            }
        }
        return 0;
    }

    public string inventoryToString()
    {
        string itemNames = "Inventory\n";
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null)
            {
                itemNames = itemNames + itemList[i] + "\n";
            }

        }
        return itemNames;
    }
}
