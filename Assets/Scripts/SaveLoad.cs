using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Asel.abi");
        SaveManagment save = new SaveManagment();
        save.HScore = GetComponent<SavedData>().HScore;
        save.CarSelect = GetComponent<SavedData>().selectedCar;
        save.Coin = GetComponent<SavedData>().Coin;
        //    save.Volume = GetComponent<MenuManager>().Value;

        binary.Serialize(file, save);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.dataPath + "/Asel.abi"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/Asel.abi", FileMode.Open);
            SaveManagment save = (SaveManagment)binary.Deserialize(file);
            GetComponent<SavedData>().HScore = save.HScore;
            GetComponent<SavedData>().selectedCar = save.CarSelect;
            GetComponent<SavedData>().Coin = save.Coin;
            // GetComponent<MenuManager>().Value = save.Volume;

            file.Close();

        }
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////
    /// </summary>
    [System.Serializable]
    public class SaveManagment
    {
        public float HScore;
        public int CarSelect;
        public int Coin;
        public float scoreValue;
        public float Volume;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Save2()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Savegame2.dat");
        SaveManagment2 save2 = new SaveManagment2();
        save2.HScore = GetComponent<SavedData>().HScore;
        save2.scoreValue = GetComponent<SavedData>().scoreValue;
        binary.Serialize(file, save2);
        file.Close();
    }
    public void Load2()
    {
        if (File.Exists(Application.dataPath + "/Savegame2.dat"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/Savegame2.dat", FileMode.Open);
            SaveManagment2 save2 = (SaveManagment2)binary.Deserialize(file);
            GetComponent<MenuGameEnd>().HighScore = save2.HScore;
            GetComponent<MenuGameEnd>().Score = save2.scoreValue;
            file.Close();
        }
    }
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    [System.Serializable]
    public class SaveManagment2
    {
        public float HScore;
        public float scoreValue;
        public int Coins;
    }
    public void Save3()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Savegame3.dat");
        SaveManagment3 save3 = new SaveManagment3();
        save3.Coins = GetComponent<SavedData>().Coin;
        binary.Serialize(file, save3);
        file.Close();
    }
    public void Load3()
    {
        if (File.Exists(Application.dataPath + "/Savegame3.dat"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/Savegame3.dat", FileMode.Open);
            SaveManagment3 save3 = (SaveManagment3)binary.Deserialize(file);
            GetComponent<MenuManager>().coins = save3.Coins;
            file.Close();
        }
    }
    [System.Serializable]
    public class SaveManagment3
    {
        public int Coins;
        public int Cash;
    }
    /////////////////////////////
    ///
    public void Save4()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Savegame4.dat");
        SaveManagment4 save4 = new SaveManagment4();
        save4.index = GetComponent<MenuManager>().index;
        binary.Serialize(file, save4);
        file.Close();
    }
    public void Load4()
    {
        if (File.Exists(Application.dataPath + "/Savegame4.dat"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/Savegame4.dat", FileMode.Open);
            SaveManagment4 save4 = (SaveManagment4)binary.Deserialize(file);
            GetComponent<SavedData>().Globalindex = save4.index;
            file.Close();
        }
    }
    [System.Serializable]
    public class SaveManagment4
    {
        public int VolumeSwitch;
        public int index;
        public int Coin;
        public int[] BoughtCar;
    }
    /////////////////////////////////////////////
    ///
    public void Save5()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Savegame5.dat");
        SaveManagment5 save5 = new SaveManagment5();
        save5.Value = GetComponent<MenuManager>().Value;
        save5.Coins = GetComponent<MenuManager>().coins;
        binary.Serialize(file, save5);
        file.Close();
    }
    public void Load5()
    {
        if (File.Exists(Application.dataPath + "/Savegame5.dat"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/Savegame5.dat", FileMode.Open);
            SaveManagment5 save5 = (SaveManagment5)binary.Deserialize(file);
            GetComponent<MenuManager>().Value = save5.Value;
            save5.Coins = GetComponent<MenuManager>().coins ;
            file.Close();
        }
    }
    [System.Serializable]
    public class SaveManagment5
    {
        public int Value;
        public int Coins;
    }
    ////////////////////////////////////////
    ///
}
