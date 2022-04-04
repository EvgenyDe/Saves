using System;
using System.IO;
using UnityEngine;

namespace Models.Police_Officer_SC.Scripts
{
    
    public class CopModel
    {
        public CopData copData;

        public float CopPosition
        {
            get => copData.copPosition;
            set => copData.copPosition = value;
        }

        public bool ForwardMoving
        {
            get => copData.forwardMoving;
            set => copData.forwardMoving = value;
        }

        public bool IsHuliganNear
        {
            get => copData.isHuliganNear;
            set => copData.isHuliganNear = value;
        }

        public CopModel()
        {
            copData = new CopData();
            GetData();
        }

        private void GetData()
        {
            if (File.Exists(Application.persistentDataPath +  "/dataPlayer.json"))
            {
                string s = File.ReadAllText(Application.persistentDataPath + "/dataCop.json"); 
                copData = JsonUtility.FromJson<CopData>(s);
                Debug.Log(s);
            }
        }
        
        
    }
}