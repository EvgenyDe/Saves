using System.IO;
using UnityEngine;

namespace Models.Player
{
    public class PlayerModel
    {
        private float posX;
        private float posZ;
        //private int countMoney=0;
        public PlayerData playerData;

        public PlayerModel()
        {
            this.playerData = new PlayerData();
            GetData();
        }

        private void GetData()
        {
            if (File.Exists(Application.persistentDataPath +  "/dataPlayer.json"))
            {
                string s = File.ReadAllText(Application.persistentDataPath + "/dataPlayer.json");
                playerData = JsonUtility.FromJson<PlayerData>(s);
            }
           
        }

        public float PosX
        {
            get => posX;
            set => posX = value;
        }

        public float PosZ
        {
            get => posZ;
            set => posZ = value;
        }

        public int CountMoney
        {
            get => playerData.countMoney;
            set => playerData.countMoney = value;
        }
    }
}
