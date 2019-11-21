using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyboxCont : MonoBehaviour
{
    public Material sky;
    public Transform  sun;
    Color32 dawn;
    Color32 day;
    Color32 dusk;
    float tillChange;
    float changeTime;
    int changes;

    void Start()
    {
        sun.eulerAngles = new Vector3(130, sun.eulerAngles.y, sun.eulerAngles.z);

        dawn = new Color32(56, 65, 80, 128);
        day = new Color32(60, 93, 145, 128);
        dusk = new Color32(255, 63, 35, 128);
        sky.color = dawn;
        changeTime = 5.0f;
        tillChange = 15.0f;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "StartMenu")
        {
            sky.color = day;
        }

        if(SceneManager.GetActiveScene().name == "MainScene2")
        {
            if (changes == 0 && sun.eulerAngles.x < 130)
            {
                sky.color = Color.Lerp(dawn, day, (5.0f - changeTime) / 5.0f);
                changeTime -= Time.deltaTime;
            }

            if (changes == 1 && sun.eulerAngles.x < 45)
            {
                sky.color = Color.Lerp(day, dusk, (5.0f - changeTime) / 5.0f);
                changeTime -= Time.deltaTime;
            }

            if (tillChange <= 0)
            {
                changes++;
                changeTime = 5.0f;
                tillChange = 600;
            }
           
            tillChange -= Time.deltaTime;
        }        
    }
}
