using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class main_ui : MonoBehaviour
{
    public int scoreValue = 0;
    TextMeshProUGUI score_element;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Find("score_value").GetComponent<TextMeshProUGUI>();
        score_element = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_ui_score(int new_value)
    {
        //score_element.text = "Score: " + scoreValue;
        score_element.text += new_value;
    }
}
