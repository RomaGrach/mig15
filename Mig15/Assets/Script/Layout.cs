using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Layout : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextButtonLayout;
    public bool isOn;

    private void Start()
    {
        isOn = Progress.Instance.PlayerInfo.Desktop;
    }


    public void Layout_type()
    {
        if (!isOn)
        {
            TextButtonLayout.text = "Desktop";
            Progress.Instance.PlayerInfo.Desktop = true;
            isOn = true;
        }
        else if (isOn)
        {
            TextButtonLayout.text = "Mobile";
            Progress.Instance.PlayerInfo.Desktop = false;
            isOn = false;
        }

    }
}
