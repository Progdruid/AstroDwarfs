using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionUI : MonoBehaviour
{
    [SerializeField] GameObject CobaltAmountUIItem;

    private TextMeshProUGUI CobaltAmountText;

    private MissionInfo info;

    public void OnInfoUpdate()
    {
        CobaltAmountText.text = ((int)info.GetResByKey("Cobalt")).ToString();
    }

    private void Start()
    {
        info = Mission.ins.MissionInfo;
        info.InfoUpdateEvent += OnInfoUpdate;

        CobaltAmountText = CobaltAmountUIItem.GetComponent<TextMeshProUGUI>();
    }
}
