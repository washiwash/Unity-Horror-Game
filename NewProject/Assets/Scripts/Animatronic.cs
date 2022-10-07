using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Animatronic : MonoBehaviour
{
    [Header("Missions")]
    public List<ItemStruct> itemsNeeded = new List<ItemStruct>();

    [System.Serializable]
    public struct ItemStruct
    {
        public string type;
        public int amount;
    }
}
