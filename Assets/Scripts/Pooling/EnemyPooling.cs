

using Assets.Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pooling
{
    public class EnemyPooling : ObjectPooling
    {

        public static EnemyPooling Instance;

        public List<ObjectData> listData;

        private void Awake()
        {
            Instance = this;

        }


        public void SpawnEnemy(Vector3 positon)
        {
            GameObject game = GetObject();
            game.transform.position = positon;
            game.GetComponent<ObjectHealth>().ResetHeal();
            game.GetComponent<Object>().data = GetRandomObjectData();

            game.SetActive(true);
        }



        public ObjectData GetRandomObjectData()
        {
            int random = Random.Range(0, listData.Count);
            return listData[random];
        }

    }
       
}
