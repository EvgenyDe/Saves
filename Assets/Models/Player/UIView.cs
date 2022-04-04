using UnityEngine;
using UnityEngine.UI;

namespace Models.Player
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private GameObject askMoneyTxt;
        [SerializeField] private Text countMoneyTxt;
        [SerializeField] private GameObject loseTxt;

        public GameObject AskMoneyTxt
        {
            get => askMoneyTxt;
            set => askMoneyTxt = value;
        }

        public Text CountMoneyTxt
        {
            get => countMoneyTxt;
            set => countMoneyTxt = value;
        }

        public GameObject LoseTxt
        {
            get => loseTxt;
            set => loseTxt = value;
        }
    }
}