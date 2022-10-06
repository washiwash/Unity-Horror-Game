using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float range = 10f;

    [Header("Keybids")]
    [SerializeField] private KeyCode keyInteract = KeyCode.E;

    public List<string> items = new List<string>();
    public Dictionary<string, int> itemDict = new Dictionary<string, int>();

    private void Update()
    {
        CheckObject();
    }

    private void CheckObject()
    {
        RaycastHit hit;
        bool raycastHit = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range);
        if (raycastHit)
        {
            if (hit.transform.tag == "Item")
            {
                Item item = hit.transform.GetComponent<Item>();
                if (Input.GetKeyDown(keyInteract))
                {
                    if (!IsInInventory(item.type))
                    {
                        items.Add(item.type);
                        itemDict[item.type] = item.amount;
                    }
                    else
                        itemDict[item.type] += item.amount;
                    item.gameObject.SetActive(false);
                    Debug.Log("Collected" + item.amount.ToString() + " " + item.type + ": Total is " + itemDict[item.type].ToString());
                }
            }
        }
    }

    private bool IsInInventory(string itemType)
    {
        foreach (string item in items)
        {
            if (item == itemType)
                return true;
        }
        return false;
    }
}
