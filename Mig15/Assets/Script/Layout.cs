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
        isOn = true;
    }


    public void Layout_type()
    {
        if (!isOn)
        {
            TextButtonLayout.text = "Desktop";

            isOn = true;
        }
        else if (isOn)
        {
            TextButtonLayout.text = "Mobile";

            isOn = false;
        }

    }
}
