using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionContainer : MonoBehaviour
{
    // public enum MissionType
    // {
    // FindObject,
    // SolvePuzzle
    // }

    // private MissionType missionType; // QUEST TYPE
    // private string missionTitle; // TITLE OF QUEST
    // private ArrayList missionReqs;// WHAT OBJECT
    // private int missionAmount; // AMOUNT
    // private GameObject missionReturn; // RETURN
    // private GameObject missionReward; // REWARDS

    [Header("Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private float range = 5f;
    
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI missionText;
    [SerializeField] private string missionTitle;

    private void Update()
    {
        DetectObject();
    }

    private void DetectObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Animatronic")
            {
                missionTitle = hit.transform.GetComponent<AnimatronicMission>().message;
                missionText.text = missionTitle;
                missionText.enabled = true;
            }
            else
            {
                missionText.enabled = false;
            }
        }
    }
}
