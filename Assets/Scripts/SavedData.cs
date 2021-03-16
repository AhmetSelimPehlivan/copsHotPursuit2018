using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedData : MonoBehaviour
{
    GameObject Buy;
    GameObject MainLock;
    GameObject Locks;
    public int selectedCar = 0;
    public int Coin = 0;
    public int Globalindex;
    public float HScore;
    public List<GameObject> cars;
    Transform tCars;
    public Text Score;
    public Text HighScore;
    public Text CoinText;
    public float scoreValue = 0;

    GameObject player;

    void Start()
    {
        GetComponent<SaveLoad>().Load();
        GetComponent<SaveLoad>().Load4();
        MainLock = GameObject.Find("Lock");
        //Fee2 = GameObject.Find("Fee2");
        //Fee3 = GameObject.Find("Fee3");
        //PnlMainMenu
        //   selectedCar = PlayerPrefs.GetInt("selectedCar", 0);
        selectedCar = 0;
        tCars = GameObject.FindGameObjectWithTag("Cars").transform;

        cars = new List<GameObject>();
        foreach (Transform t in tCars)
        {
            cars.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        cars[selectedCar].SetActive(true);

        //PlayerPrefs.SetFloat("Score", 0);
        scoreValue = 0;
        CoinText.text = Coin + "";
        HighScore.text = HScore.ToString("F2"); /*PlayerPrefs.GetFloat("HighScore", 0).ToString("F2");*/
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<SaveLoad>().Save3();
    }

    void Update()
    {
        if (player)
        {
            scoreValue += Time.deltaTime;
            GetComponent<SaveLoad>().Save2();
        }
        if (Score)
        {
            Score.text = scoreValue.ToString("F2"); //.ToString("F2");
        }
        if (scoreValue > HScore /*PlayerPrefs.GetFloat("HighScore", 0)*/ /*&& PlayerBehaviour.hasExplosed*/)
        {
            //PlayerPrefs.SetFloat("HighScore", scoreValue);
            HScore = scoreValue;
            HighScore.text = scoreValue.ToString("F2"); //.ToString("F2");
            Coin += 2;
            CoinText.text = Coin + "";
     //       CoinMenuSelect.text = Coin + "";
            GetComponent<SaveLoad>().Save();
            GetComponent<SaveLoad>().Save2();
            GetComponent<SaveLoad>().Save3();
        }
    }

    void OnDestroy()
    {
        //   PlayerPrefs.SetInt("selectedCar", selectedCar);
        //   PlayerPrefs.SetFloat("Score", scoreValue);
        GetComponent<SaveLoad>().Save();
    }

    public void Select(int index)
    {
        if (index == selectedCar)
            return;
        if (index < 0 || index >= cars.Count)
            return;

        cars[selectedCar].SetActive(false);
        selectedCar = index;
        cars[selectedCar].SetActive(true);
    }

}
