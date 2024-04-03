using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingPosition : MonoBehaviour
{
    public GameObject panelSettings;

    public void Settings()
    {
        if(panelSettings.activeSelf == false)
        {
            panelSettings.SetActive(true);
        }
        else if(panelSettings.activeSelf == true)
        {
            panelSettings.SetActive(false);
        }
    }
}
