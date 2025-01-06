
using System.Collections;

using UnityEngine;

namespace Assets.Scripts.Health
{
    public class PlayerHealth : ObjectHealth
    {
        private void FixedUpdate()
        {
            if (IsDead())
            {
                StartCoroutine(DestroyObject());
            }
        }

        private IEnumerator DestroyObject()
        {
            SetDeadAnimation();
            yield return new WaitForSeconds(1f);
            ManageGame.Instance.SetEndGame();
            gameObject.SetActive(false);

        }

    }
}
