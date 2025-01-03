
using Assets.Scripts.Event;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Enemy
{
    public class EnemyDirection : MonoBehaviour
    {
        public RawImage arrow;

        public Transform onwer;

        private Transform player;

        private void OnEnable()
        {
            ArrowEvent.Arrow += setArrow;
        }



        private void Update()
        {
            UpdateArrow();
        }

        private void OnDisable()
        {
            ArrowEvent.Arrow -= setArrow;
        }
      


        private void setArrow(Transform game)
        {
            player = game;
        }
        private void UpdateArrow()
        {
            if (player == null) return;
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(onwer.position);

            if(screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            {
                arrow.gameObject.SetActive(true);
                Vector3 direction = transform.position - player.position;
                direction.Normalize();
                float Angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

                Vector3 display = new Vector3(
                    Mathf.Clamp(screenPoint.x, 0.05f, 0.95f),
                    Mathf.Clamp(screenPoint.y, 0.05f, 0.95f),
                    0);
                arrow.gameObject.transform.position = new Vector3(display.x*Screen.width, display.y*Screen.height, 0);
                if(screenPoint.x < 0)
                {
                    arrow.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle + 90));
                }
                else
                {
                    arrow.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle - 90));
                }
                
            }
            else
            {
                arrow.gameObject.SetActive(false);
            }
        }
    }
}
