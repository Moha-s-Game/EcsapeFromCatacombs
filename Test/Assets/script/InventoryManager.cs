using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Sounds
{
    public static InventoryManager Instance;
    public GameObject Runner;

    public List<AllItems> _inventoryItems = new List<AllItems>();
    
    private void Awake()
    {
        Instance = this;
        Runner.SetActive(false);
    }
    public void AddItem(AllItems item)
    {
        if (!_inventoryItems.Contains(item))
        {
            PlaySound(sounds[0], 1);
            _inventoryItems.Add(item);
            if(item == AllItems.RedKey)
            {
                PlaySound(sounds[1], 6);
                _inventoryItems.Add(item);
                Runner.SetActive(true);
            }
        }
    }
    public void RemoveItem(AllItems item)
    {
        if (!_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }
    }
    public enum AllItems
    {
        Key,
        RedKey,
        BlueKey,
        GreenKey,      
        GrayKey,
        GrayKey1,
        GrayKey2,
        GrayKey3,
    }
}
