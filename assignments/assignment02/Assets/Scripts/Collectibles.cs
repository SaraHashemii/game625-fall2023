using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Wood,
    Stone
}

public class Collectibles : MonoBehaviour
{
    public string itemName;
    public ItemType type;
}
