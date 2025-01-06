using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Pooling
{
    public class ObjectPooling : MonoBehaviour
    {

        public static ObjectPooling instance;


        [SerializeField] private GameObject objectPool;

        private List<GameObject> listObject = new List<GameObject>();


        private void Start()
        {
            instance = this;
        }


        public GameObject GetObject()
        {
            for(int i = 0;  i < listObject.Count; i++)
            {
                if (!listObject[i].activeSelf) return listObject[i];
            }

            GameObject objectSpawn = Instantiate(objectPool, transform);
            objectSpawn.name = objectPool.name;
            listObject.Add(objectSpawn);
            return objectSpawn;
        }

        public void SetDisActiveObject()
        {
            foreach (GameObject obj in listObject)
            {
                obj.SetActive(false);
            }
        }



        public int getAmountObject()
        {
            int count = 0;
            foreach(var item in  listObject)
            {
                if (item.activeSelf) count++;
            }
            return count;
        }










    }
}
