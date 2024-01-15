using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]private GameObject _obstacal,_background;

    [SerializeField]private float _spawnerTime = 3f,_realTime,_spawnerRange = 30f;

    [SerializeField]private float _backgroundTime = 3f,_Backgroundime;

    
    
    private void Awake()
    {
        _realTime = _spawnerTime;
        _Backgroundime = _backgroundTime;

    }//Awake
    private void Update()
    {
        _spawnerTime -= Time.deltaTime;
        if(_spawnerTime <= 0)
        {
            _spawnerTime = _realTime;
            Spawnner();
        }
    
        _backgroundTime-= Time.deltaTime;
        if(_backgroundTime <=0)
        {
            _backgroundTime =_Backgroundime;
            BackgroundSpawner();
        }


    }//Update
    private void Spawnner()
    {
        float randomY = Random.Range(-_spawnerRange,_spawnerRange);
        Instantiate<GameObject>(_obstacal,new Vector3(transform.position.x,randomY,0f),Quaternion.identity);
    }//Spawnner
    private void BackgroundSpawner()
    {
        Instantiate<GameObject>(_background,new Vector3(616,-3,0f),Quaternion.identity);

    }//BackgroundSpawner
}//Class
