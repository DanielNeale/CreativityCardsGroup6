using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxCont : MonoBehaviour
{
    Color dawn;
    Color day;
    Color dusk;
    float tillChange;
    float changeTime;
    bool changing;

    void Start()
    {
        dawn = new Color(157, 174, 201, 128);
        day = new Color(70, 128, 219, 128);
        dusk = new Color(3, 48, 77, 128);
        RenderSettings.skybox.SetColor("dawn", dawn);
        changeTime = 5.0f;
    }

    void Update()
    {       
        if (tillChange <= 0)
        {
            if (changing == false)
            {
                changeTime = 5.0f;
                changing = true;
            }

            if (RenderSettings.skybox.HasProperty("dawn"))
            {
                float rDist = ((dawn.r - day.r) * ((5.0f - changeTime) / 5.0f));
                float gDist = ((dawn.g - day.g) * ((5.0f - changeTime) / 5.0f));
                float bDist = ((day.b - dawn.b) * ((5.0f - changeTime) / 5.0f));
                
                Color colorChange = new Color(rDist, gDist, bDist, 128);
                Color oldColour = RenderSettings.skybox.GetColor("dawn");
                Color newColour = oldColour + colorChange;

                RenderSettings.skybox.SetColor("dawn", newColour);
                changeTime -= Time.deltaTime;
            }

            if (RenderSettings.skybox.HasProperty("day"))
            {
                float rDist = ((day.r - dusk.r) * ((5.0f - changeTime) / 5.0f));
                float gDist = ((day.g - dusk.g) * ((5.0f - changeTime) / 5.0f));
                float bDist = ((day.b - dusk.b) * ((5.0f - changeTime) / 5.0f));

                Color colorChange = new Color(rDist, gDist, bDist, 128);
                Color oldColour = RenderSettings.skybox.GetColor("dawn");
                Color newColour = oldColour + colorChange;

                RenderSettings.skybox.SetColor("dawn", newColour);
                changeTime -= Time.deltaTime;
            }

            if (changeTime <= 0 && RenderSettings.skybox.HasProperty("dawn"))
            {
                RenderSettings.skybox.SetColor("day", day);
                tillChange = 20.0f;
                changing = false;
            }

            if (changeTime <= 0 && RenderSettings.skybox.HasProperty("day"))
            {
                RenderSettings.skybox.SetColor("dusk", day);
                tillChange = 20.0f;
                changing = false;
            }
        }

        DynamicGI.UpdateEnvironment();
        tillChange -= Time.deltaTime;
    }
}
