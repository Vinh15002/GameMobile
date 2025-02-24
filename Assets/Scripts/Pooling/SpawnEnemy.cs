using Assets.Scripts.Pooling;
using TMPro;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private TMP_Text aliveEnemy;
    [SerializeField] private Transform postionO;
    [SerializeField] private Transform positionMaxX;
    [SerializeField] private Transform positionMaxZ;
    [SerializeField] private const int MAX_ENEMY  = 50;
    [SerializeField] private int maxEnemy = 50;
    [SerializeField] private int displayEnemy = 10;
    private float TimeToSpawn = 1f;
    private float _timeToSpawn = 0f;




    public void OnEnable()
    {
        Reset();
    }
    public void OnDisable()
    {
        EnemyPooling.Instance.SetDisActiveObject();
    }

    public void Reset()
    {
        maxEnemy = MAX_ENEMY;
    }



    private void FixedUpdate()
    {
        displayaAmountEnemy();
        Spawn();
        
        
    }

    private void displayaAmountEnemy()
    {
        aliveEnemy.text = $"Alive: {maxEnemy}";
    }


    public void Spawn()
    {
        if(displayEnemy > EnemyPooling.Instance.getAmountObject() && maxEnemy >=0 && _timeToSpawn >= TimeToSpawn)
        {
            SpawnRandomEnemy();
            maxEnemy--;
            _timeToSpawn = 0;
        }
        _timeToSpawn += Time.deltaTime;
    }








    


    public void SpawnRandomEnemy()
    {

        Vector3 randomPositon = getRandomPosition();
        EnemyPooling.Instance.SpawnEnemy(randomPositon);
        
       
    }


    public Vector3 getRandomPosition()
    {
        float maxX = Vector3.Distance(positionMaxX.transform.position, postionO.transform.position);
        float maxZ = Vector3.Distance(positionMaxZ.transform.position, postionO.transform.position);
        float randomX  = Random.Range(0f, maxX);
   
        float  randomZ = Random.Range(0f, maxZ);
      
        return new Vector3(randomX + postionO.transform.position.x, 0, -randomZ + postionO.transform.position.z);
    }
}
