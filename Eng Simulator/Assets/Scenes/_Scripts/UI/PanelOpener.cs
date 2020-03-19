using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{

    public GameObject bullet;
    public GameObject Panel;
    // add spriterenderer and start()


    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf; // returns true if panel is active

            Panel.SetActive(!isActive); // if panel is currently inactive, activate

            Time.timeScale = (!isActive) ? 0f : 1f; // pause game (timescale 0) if panel is activated 
        }
    }
}
