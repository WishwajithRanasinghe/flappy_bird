using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]private GameObject _obstacal;
    [SerializeField]private GameObject[] _cloude; 
    [SerializeField]private float _spawnerTime = 3f,_realTime,_spawnerRange = 30f;
    [SerializeField]private float _cloudeSpawnerTime = 3f,_cloudeTime;
    [SerializeField]private float[] _cloudeSpawnerRange;
    
    
    private void Awake()
    {
        _realTime = _spawnerTime;
        _cloudeTime = _cloudeSpawnerTime;

    }//Awake
    private void Update()
    {
        _spawnerTime -= Time.deltaTime;
        if(_spawnerTime <= 0)
        {
            _spawnerTime = _realTime;
            Spawnner();
        }
        _cloudeSpawnerTime -= Time.deltaTime;
        if(_cloudeSpawnerTime <=0)
        {
            _cloudeSpawnerTime =_cloudeTime;
            CloudeSpawner();
        }


    }//Update
    private void Spawnner()
    {
        float randomY = Random.Range(-_spawnerRange,_spawnerRange);
        Instantiate<GameObject>(_obstacal,new Vector3(transform.position.x,randomY,0f),Quaternion.identity);
    }//Spawnner
    private void CloudeSpawner()
    {
        float cloudeRandomY = Random.Range(_cloudeSpawnerRange[0],_cloudeSpawnerRange[1]);
        int randomObject = Random.Range(0,_cloude.Length);
        Instantiate<GameObject>(_cloude[randomObject],new Vector3(transform.position.x,cloudeRandomY,0f),Quaternion.identity);

    }//CloudeSpawner
}//Class
