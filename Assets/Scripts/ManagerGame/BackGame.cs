using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ManagerGame
{
    public class BackGame : MonoBehaviour
    {
        [SerializeField] private Transform postionSpawn;
        [SerializeField] private GameObject Player;

        [SerializeField] private Button btnBack;

        private void OnEnable()
        {
            btnBack.onClick.AddListener(() => SetBackGame());
        }
        private void OnDisable()
        {
            btnBack.onClick.RemoveAllListeners();
        }


        public void SetBackGame()
        {
            Player.transform.position = postionSpawn.position;
            Player.SetActive(true);
            Player.GetComponent<ObjectHealth>().ResetHeal();
            ManageGame.Instance.BackGame();
            gameObject.SetActive(false);

        }

    }
}
