using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private Text theText;
    private float lvlTime;
    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();
        lvlTime = GameController.finalLevelTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (lvlTime != 0)
        {
            float minutes = Mathf.Floor(lvlTime / 60F);
            float seconds = Mathf.RoundToInt(lvlTime % 60);
            float ms = Mathf.RoundToInt(lvlTime * 1000);

            string niceTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, ms);
            theText.text = niceTime;
            lvlTime = 0;
        }
    }
}
