using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class KillandFlightcounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KilledScoreText;
    [SerializeField] TextMeshProUGUI FlightScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KilledScoreText.text = Progress.Instance.PlayerInfo.Killed.ToString();
        FlightScoreText.text = Progress.Instance.PlayerInfo.Flight.ToString();
    }
}
