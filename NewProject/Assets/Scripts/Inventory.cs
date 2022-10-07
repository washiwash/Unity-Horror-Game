using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float range = 10f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI pickUpText;

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
                pickUpText.text = "Press '" + keyInteract.ToString() + "' to pick up";
                pickUpText.enabled = true;
            }
            else if (hit.transform.tag == "Animatronic")
            {
                Animatronic anima = hit.transform.GetComponent<Animatronic>();
                Animator animaAnim = hit.transform.GetComponent<Animator>();
                List<Animatronic.ItemStruct> itemsNeeded = anima.itemsNeeded;
                
                if (IsInInventory(itemsNeeded[0].type) && itemDict[itemsNeeded[0].type] >= itemsNeeded[0].amount)
                {
                    pickUpText.text = "Press " + keyInteract.ToString() + " to fix";
                    pickUpText.color = Color.green;

                    if (Input.GetKeyDown(keyInteract))
                    {
                        FixAnima(animaAnim);
                        foreach (Animatronic.ItemStruct item in itemsNeeded)
                        {
                            itemDict[item.type] -= 1;
                            Debug.Log(itemDict[item.type]);
                            if (itemDict[item.type] <= 0)
                            {
                                itemDict.Remove(item.type);
                                items.Remove(item.type);
                            }
                        }
                    }
                }
                else
                {
                    pickUpText.text = itemsNeeded[0].amount.ToString() + " " + itemsNeeded[0].type + " needed";
                    pickUpText.color = Color.white;
                }
                if (animaAnim.GetBool("Fixed"))
                    pickUpText.text = "Fixed";

                pickUpText.enabled = true;
            }
            else
            {
                pickUpText.enabled = false;
            }
        }
        else
        {
            pickUpText.enabled = false;
        }
    }

    private void FixAnima(Animator animaAnim)
    {
        animaAnim.SetBool("Fixed", true);
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
