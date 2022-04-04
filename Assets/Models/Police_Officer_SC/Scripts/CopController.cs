using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Models.Police_Officer_SC.Scripts;
using UnityEngine;

public class CopController : MonoBehaviour
{
    [SerializeField] private float copPosInController;
    public CopModel copModel;
    private int speedCop = 2;
    
    
    void Start()
    {
        copModel = new CopModel();
    }

    private void Update()
    {
        
        if (copModel.ForwardMoving)
        {
            ForwardMove();
        }
        else
        {
           BackMove();
        }
        
    }

    
    void ForwardMove()
    {
        transform.position+=Vector3.forward*Time.deltaTime*speedCop;
        if (transform.position.z > 15)
        {
            SetData();
        } 
        
    }
    void BackMove()
    {
        transform.position+=Vector3.back*Time.deltaTime*speedCop;
        if (transform.position.z < 6)
        {
            SetData();
        }
    }

    void SetData()
    {
        copModel.ForwardMoving = !copModel.ForwardMoving;
        copModel.CopPosition = transform.position.z;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        copModel.IsHuliganNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        copModel.IsHuliganNear = false;
    }

    private void OnDestroy()
    {
        string s = JsonUtility.ToJson(copModel);
        File.WriteAllText(Application.persistentDataPath + "/dataCop.json", s);
        Debug.Log(s);
    }
}