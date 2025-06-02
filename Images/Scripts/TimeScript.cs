using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    Text Timer;
    private float time = 0.0f;
    private float z;
    public static bool reset;
    // Start is called before the first frame update
    void Start()
    {
        reset = false;
        Timer = GetComponent<Text>();

          if(DifficultyScript.e)
        {
            z = 300f;
        }
        else if(DifficultyScript.m)
        {
            z = 180f;
        }
        else if(DifficultyScript.h)
        {
            z = 120f;
        }
      time = z;
    }

    // Update is called once per frame
    void Update()
    {
        if(reset)
        {
        time = z;
        reset = false;
        }

        time = time - Time.deltaTime;
    }
    void Display()
    {
        Timer.text = string.Format("{0:000}",time);
    }
}
