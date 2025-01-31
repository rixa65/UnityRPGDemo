using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject playerObject;
    [SerializeField] TMP_Dropdown resolutionDropDown;
    [SerializeField]Slider mouseSensitivitySlider;
    [SerializeField]TextMeshProUGUI sensitivityValueTxt;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        mouseSensitivitySlider.value = playerObject.GetComponent<PlayerLook>().GetSensitivity();
        sensitivityValueTxt.text = playerObject.GetComponent<PlayerLook>().GetSensitivity().ToString();
        PopulateResDropDown();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value;
        playerObject.GetComponent<PlayerLook>().SetSensitivity(newSensitivity);
        sensitivityValueTxt.text = newSensitivity.ToString();
    }
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    private void PopulateResDropDown()
    {
        int currentResIndex = 0;
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            options.Add(resolution.width.ToString()+"x"+ resolution.height.ToString());
            if(Screen.currentResolution.width == resolution.width && Screen.currentResolution.height == resolution.height)
            {
                currentResIndex = Array.IndexOf(resolutions, resolution);
            }
        }
        resolutionDropDown.ClearOptions();
        foreach(String resolutionString in options)
        {
            resolutionDropDown.AddOptions(options);
        }
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }
    public void ChangeResolution(int resIndex)
    {
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, Screen.fullScreen);
    }
}
