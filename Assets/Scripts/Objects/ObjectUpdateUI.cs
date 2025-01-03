
using TMPro;

using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Objects
{
    public class ObjectUpdateUI : MonoBehaviour
    {
       
        [SerializeField] private TMP_Text myScore;
        [SerializeField] private RawImage backgound;
        [SerializeField] private TMP_Text objectName;


        [SerializeField] private Transform position;


        public void OnEnable()
        {
            UpdateScore(1);
        }


        private void Update()
        {
            ShowLevel();
        }

        private void ShowLevel()
        {
            transform.forward = Camera.main.transform.forward;
            GetComponent<RectTransform>().transform.localPosition = new Vector3(0,position.position.y,0);
        }


        public void SetUpUI(string name, Color color)
        {
            objectName.text = name;
            objectName.color = color;
            backgound.color = color;
        }



        public void UpdateScore(int score)
        {
            myScore.text = score.ToString();
           

        }













    }
}
