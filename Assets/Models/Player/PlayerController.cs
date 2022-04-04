using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using Models.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerModel playerModel;
    private CopController copCheckerScript;
    
    [SerializeField] private GameObject cop;
     
    [SerializeField]private InputService inputService;
    [SerializeField]private UIView uiView;
    [SerializeField]private MySceneManager mySceneManager;
    
    [SerializeField]private int speed = 8;
    
    void Start()
    {
        playerModel = new PlayerModel();
        inputService.OnSave += SaveData;
        copCheckerScript = cop.GetComponent<CopController>();
        
        uiView.CountMoneyTxt.text = playerModel.CountMoney.ToString();
    }

    public void ResetData()
    {
        playerModel.playerData.countMoney = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(inputService.LeftRightPlayerDir, 0f,inputService.ForwardPlayerDir) 
                              * Time.deltaTime*speed;

        playerModel.PosX = transform.position.x;
        playerModel.PosZ = transform.position.z;
    }
    
    private void SaveData()
    {
        string s = JsonUtility.ToJson(playerModel.playerData);
        File.WriteAllText(Application.persistentDataPath + "/dataPlayer.json", s);
    }

    private void OnDestroy()
    {
        inputService.OnSave -= SaveData;
        inputService.OnGiveMeMoney -=GetMoney;
    }

    private void OnTriggerEnter(Collider other)
    {
        inputService.OnGiveMeMoney += GetMoney;
        uiView.AskMoneyTxt.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inputService.OnGiveMeMoney -= GetMoney;
        uiView.AskMoneyTxt.SetActive(false);

    }
    

    private void GetMoney()
    {
       
        if (copCheckerScript.copModel.IsHuliganNear)
        {
            Debug.Log("Потрачено");
            StartCoroutine(YouLose());
        }
        else
        {
            playerModel.CountMoney += 5;
            uiView.CountMoneyTxt.text = playerModel.CountMoney.ToString();
            Debug.Log("you got money"); 
        }

        CheckMoneyEnough();
        
    }

    private void CheckMoneyEnough()
    {
        if (playerModel.CountMoney > 50)
        {
            SaveData();
            mySceneManager.NextScene();
        }
    }

    IEnumerator YouLose()
    {
        yield return new WaitForSeconds(0.2f);
        uiView.LoseTxt.SetActive(true);
        ResetData();
        SaveData();
        yield return new WaitForSeconds(2f);
        mySceneManager.GameOver();
    }
}
