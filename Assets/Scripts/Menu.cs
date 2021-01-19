using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using DG.Tweening;
public class Menu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject SettingsPanel;
    public GameObject Gold_Panel;
    public void Start_Button()
    {
        MainPanel.SetActive(false);
        Gold_Panel.SetActive(true);
        Time.timeScale = 1;
        Manager.instance.thegame = true;
    }
    public void Exit_Button()
    {
        Application.Quit();
    }
    public void Settings_Button()
    {
        MainPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void Back_Button()
    {
        SettingsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
}
