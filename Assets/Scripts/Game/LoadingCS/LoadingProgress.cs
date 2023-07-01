using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Framework;

public class LoadingProgress : MonoBehaviour
{
    [SerializeField] private GameObject loadingBar; 
    private float fillAmount = 0f;
    private float randomNumberFillAmount = 0f;
    private float numberUpdate = 0f;
    private float MaxLoading = 100f;
    private float timeUpdate = 0f;
    private float timeRun = 0f;
    // Update is called once per frame
    private void Start()
    {
        timeUpdate = Random.Range(1f, 3f);
    }
    void Update()
    {
        this.loadingStart();
    }
    private void loadingStart()
    {
        loadingBar.transform.GetComponent<Image>().fillAmount = numberUpdate / MaxLoading;
        if (loadingBar.transform.GetComponent<Image>().fillAmount < 1)
        {
            timeRun += Time.deltaTime;
            if(timeRun >= timeUpdate)
            {
                timeRun = 0f;
                timeUpdate = Random.Range(0.1f, 0.5f);
                randomNumberFillAmount = Random.Range(1f, 10f);
                numberUpdate += randomNumberFillAmount;
            }  
        }
        else
        {
            Debug.Log(" Go home scene ");
            SceneTransitionHelper.Load(ESceneName.HomeScene);
        }
    }
}
