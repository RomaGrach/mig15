using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextButtonLanguage;
    public bool isRu;

    private void Start()
    {
        isRu = true;
    }


    public void user_language()
    {
        if (!isRu)
        {
            TextButtonLanguage.text = "Русский";
 
            isRu = true;
        }
        else if (isRu)
        {
            TextButtonLanguage.text = "English";

            isRu = false;
        }

    }
}
