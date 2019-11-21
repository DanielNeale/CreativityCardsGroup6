using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxCont : MonoBehaviour
{
    public Material sky;
    Color32 dawn;
    Color32 day;
    Color32 dusk;
    float tillChange;
    float changeTime;
    int changes;

    void Start()
    {
        dawn = new Color32(56, 65, 80, 128);
        day = new Color32(60, 93, 145, 128);
        dusk = new Color32(255, 63, 35, 128);
        sky.color = dawn;
        changeTime = 5.0f;
        tillChange = 15.0f;
    }

    void Update()
    {
        if (changes == 0)
        {
            sky.color = Color.Lerp(dawn, day, (5.0f - changeTime) / 5.0f);
        }

        if (changes == 1)
        {
            sky.color = Color.Lerp(day, dusk, (5.0f - changeTime) / 5.0f);
        }

        if (tillChange <= 0)
        {
            changes++;
            changeTime = 5.0f;
            tillChange = 600;
        }

        changeTime -= Time.deltaTime;
        tillChange -= Time.deltaTime;
    }
}
