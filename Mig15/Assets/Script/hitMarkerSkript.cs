using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitMarkerSkript : MonoBehaviour
{
    public GameObject imageObject;
    float timeHitMarker;
    public float MainTimeHitMarker = 1f;
    // Start is called before the first frame update
    public void startHitMarker()
    {
        imageObject.SetActive(true);
        timeHitMarker = MainTimeHitMarker;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeHitMarker <= 0)
        {
            imageObject.SetActive(false);
        }
        else
        {
            timeHitMarker -= Time.deltaTime;
        }
    }


}
