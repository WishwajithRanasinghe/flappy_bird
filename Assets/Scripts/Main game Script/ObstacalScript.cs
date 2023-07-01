using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacalScript : MonoBehaviour
{
    [SerializeField]private float _moveSpeed = 1.2f;
    [SerializeField]private float _destroyTime = 5f;
    private Rigidbody2D _rBody;
    private void Awake()
    {
       _rBody = GetComponent<Rigidbody2D>(); 

    }//Awake
    private void Update()
    {
        _rBody.velocity = Vector2.left*_moveSpeed;
        Destroy(this.gameObject,_destroyTime);

    }//Update


}//Class
