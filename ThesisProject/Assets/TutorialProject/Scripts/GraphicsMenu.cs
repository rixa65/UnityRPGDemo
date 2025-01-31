using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject playerObject;
    TMP_Dropdown resolutionDropDown;
    [SerializeField]Slider mouseSensitivitySlider;
    [SerializeField]TextMeshProUGUI sensitivityValueTxt;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        sensitivityValueTxt.text = playerObject.GetComponent<PlayerLook>().GetSensitivity().ToString();
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
}
