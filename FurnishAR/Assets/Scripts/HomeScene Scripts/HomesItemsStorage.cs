using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HomesItemsStorage 
{
    public Sprite Sprite;
    public string Name;
    public string Price;

    public HomesItemsStorage()
    {
        
    }

    public HomesItemsStorage(string name, string price, Sprite sprite)
    {

        Sprite = sprite;
        Name = name;
        Price = price;
    }
    
    
}
