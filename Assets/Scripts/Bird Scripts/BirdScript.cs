using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private const float _jumpForce = 100f;
    [SerializeField]private AudioClip _hitClip,_pointClip;
    private AudioSource _audioSource;
    private Rigidbody2D _rBody;
    private int _score;
    private bool _dying;
    enum State {ALIVE,DYING};
    State state = State.ALIVE;
    private int _check;
    private void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }//Awake
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(state == State.ALIVE)
            {
                Jump();
            }
            
        }

    }//Update
    private void Jump()
    {
        _rBody.velocity = Vector2.up * _jumpForce;
        Debug.Log("Space");
    }//Jump
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.tag == "Obstacal")
        {
            Time.timeScale = 0.2f;
            state = State.DYING;
            if(_dying == true){return;}
            _audioSource.PlayOneShot(_hitClip);
            Debug.Log("Dead!");
            _dying = true;
            
            
        }
        if(collider.transform.tag == "Point")
        {
            _audioSource.PlayOneShot(_pointClip);
            Debug.Log("Point");
            _score ++;
        }
    }//OnTriggerEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Wall")
        {
            Time.timeScale = 0.2f;
            state = State.DYING;
            if(_dying == true){return;}
            _audioSource.PlayOneShot(_hitClip);
            Debug.Log("Dead!");
            _dying = true;
            
            
        }

    }//OnCollisionEnter2D
    public int Score()
    {
        return _score;
    }//Score
    public bool Dying()
    {
        return _dying;

    }//Dying

}//Class
