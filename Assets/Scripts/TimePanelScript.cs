using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimePanelScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer()
    {
        timerText.text = System.DateTime.Now.ToString("HH:mm");
    }


}
