using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<string, int> inventory = new Dictionary<string, int>()
    {
        {"Food", 5},
        {"Water", 5},
        {"Medicine", 1}
    };
}
