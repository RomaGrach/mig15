using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Off_sounds : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextButtonSound;
    public bool isOn;

    private void Start()
    {

        isOn = true;

    }
    void Update()
    {
        if (isOn == false)
        {
            TextButtonSound.text = "��������";
        }
    }
 
    public void OnOffSound()
    {
        if(!isOn)
        {
            TextButtonSound.text = "�������";
            AudioListener.volume = 1f;
            isOn = true;
        }
        else if (isOn)
        {
            TextButtonSound.text = "��������";
            AudioListener.volume = 0f;
            isOn = false;
        }

    }
}
