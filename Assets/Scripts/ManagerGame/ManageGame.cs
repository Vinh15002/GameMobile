using System;
using System.Collections;

using TMPro;
using UnityEngine;


public class ManageGame : MonoBehaviour
{
    [SerializeField] private GameObject SpawnEnemy;
    [SerializeField] private GameObject EndGame;
    [SerializeField] private GameObject GameBack;
    [SerializeField] private GameObject buttonShop;

    [SerializeField] private GameObject Loading;
    [SerializeField] private TMP_Text TimeDisplayText;
    

    private float timeDisplay = 5f;


    public static ManageGame Instance;

    private void Start()
    {
        Instance = this;
    }


    public void SetGameStart()
    {
        SpawnEnemy.SetActive(true);
    }

    public void SetEndGame()
    {
        EndGame.SetActive(true);
        StartCoroutine(CountDownCoroutine());
    }

    private IEnumerator CountDownCoroutine()
    {
        float _time = timeDisplay;
        while(_time > -0.5)
        {

            TimeDisplayText.text = Mathf.Ceil(_time).ToString();
            Loading.transform.Rotate(0, 0, -10);
            yield return null;
            _time -= Time.deltaTime;
        }
        EndGame.SetActive(false);
        GameBack.SetActive(true);
    }

    public void BackGame()
    {
        SpawnEnemy.SetActive(false);
        buttonShop.SetActive(true);
        ManagerCameraPlayer.Instance.SetCamOff();
    }
}
