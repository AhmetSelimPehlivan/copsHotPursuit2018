using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    GameObject Lock, Buy, Video;
    public int index;
    public int[] ActiveCars;
    public int selectedCar = 0;
    GameObject VolumeOn, volumeOff;
    public GameObject pnlMainMenu;
    public GameObject pnlCarSelectMenu;
    public GameObject pnlSettingsMenu;
    public Text Coins;
    public int coins;
    public int Value;
    public int VolumeSwitch;
    public AudioMixer volumeMixer;
    private void Start()
    {
        GetComponent<SaveLoad>().Load5();
        GetComponent<SaveLoad>().Load3();
        VolumeOn = GameObject.Find("VolumeOn");
        volumeOff = GameObject.Find("VolumeOff");
        Lock = GameObject.Find("Lock");
        Buy = GameObject.Find("Buy");
        Video = GameObject.Find("Advertisment");
        volumeMixer.SetFloat("volume", Value);
        Coins.text = coins + "";
        if (Value == -80)
        {
            volumeOff.SetActive(true);
            VolumeOn.SetActive(false);
        }
        else
        {
            volumeOff.SetActive(false);
            VolumeOn.SetActive(true);
        }

        pnlCarSelectMenu.SetActive(false);
        pnlSettingsMenu.SetActive(false);
        pnlMainMenu.SetActive(true);
        Video.SetActive(false);
        Buy.SetActive(false);
        Lock.SetActive(false);
    }
    public void Update()
    {
        Coins.text = coins + "";
    }

    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Return()
    {
        pnlCarSelectMenu.SetActive(false);
        pnlSettingsMenu.SetActive(false);
        pnlMainMenu.SetActive(true);
    }
    public void VolumeSettings()
    {
        //   PlayerPrefs.GetInt("Volume"); 
        VolumeSwitch++;
        if (VolumeSwitch % 2 == 1)
        {
            volumeOff.SetActive(true);
            VolumeOn.SetActive(false);
            volumeMixer.SetFloat("volume", -80);
            Value = -80;
        }
        else
        {
            volumeOff.SetActive(false);
            VolumeOn.SetActive(true);
            volumeMixer.SetFloat("volume", 0);
            Value = 0;
        }

       GetComponent<SaveLoad>().Save5();
        //   PlayerPrefs.SetInt("Volume", VolumeSwitch);
    }

    public void OnSettingsMenu()
    {
        pnlSettingsMenu.SetActive(true);
        pnlCarSelectMenu.SetActive(false);
        pnlMainMenu.SetActive(false);
    }
    public void GraphicsSettings(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void OnCarSelectMenu()
    {
        pnlMainMenu.SetActive(false);
        pnlSettingsMenu.SetActive(false);
        pnlCarSelectMenu.SetActive(true);
    }

    public void Select(int index)
    {
        int[] ActiveCars = new int[12];
        for (int j = 0; j < 12; j++)
        {
            if (index == ActiveCars[j])
            {
                Debug.Log("geldi");
                Lock.SetActive(false);
                Video.SetActive(false);
                Buy.SetActive(false);
                break;
            }
            else
            {
                Lock.SetActive(true);
                Video.SetActive(true);
                Buy.SetActive(true);
                break;
            }
        }
        GetComponent<SaveLoad>().Save4();
    }

    public void buy(int index)
    {
        int[] ActiveCars = new int[12];
        for (int j = 0; j < 12; j++)
        {
            if (index != ActiveCars[j])
            {
                coins -= 750;
  //              GetComponent<SaveLoad>().Save5();
                ActiveCars[1] = 1;
                Debug.Log(coins);
                //Lock.SetActive(false);
                //Video.SetActive(false);
                //Buy.SetActive(false);

                break;

                //for(int i =0;i<12;i++)
                //{
                //    if (index == i)
                //    {
                //        coins -= 750;
                //        ActiveCars[i] = i;
                //    }
                //}
            }
        }
    }
}
