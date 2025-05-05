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

    public void addItem(string name, int count)
    {
        if (inventory.ContainsKey(name))
        {
            inventory[name] += count;
        }
        else
        {
            inventory[name] = count;
        }
    }

    void Update() // 확인용
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (KeyValuePair<string, int> pair in inventory)
            {
                Debug.Log($"아이템: {pair.Key}, 수량: {pair.Value}");
            }
        }
    }
}
