using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float _minrotateSpeed, _maxrotateSpeed;
    private float _curentrotateSpeed;
    [SerializeField] private float _minrotateTime, _maxrotateTime;
    private float rotateTime;
    private float currentrotateTime;

    private void Awake()
    {
        currentrotateTime = 0;
        _curentrotateSpeed = _minrotateSpeed +(_maxrotateSpeed - _minrotateSpeed) * 0.1f *Random.Range(0, 11);
        rotateTime = _minrotateTime + (_maxrotateTime - _minrotateTime) * 0.1f * Random.Range(0, 11);
        rotateTime = Random.Range(_minrotateTime, _maxrotateTime);
        rotateTime *= Random.Range(0, 2) == 0 ? -1 : 1;
    }

    private void Update()
    {
        currentrotateTime += Time.deltaTime;
        if (currentrotateTime > rotateTime)
        {
            currentrotateTime = 0;
            _curentrotateSpeed *= -1;
            rotateTime = _minrotateTime + (_maxrotateTime - _minrotateTime) * 0.1f * Random.Range(0, 11);
            rotateTime *= Random.Range(0 ,2) == 0 ? -1 : 1;
        }
      
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _curentrotateSpeed * Time.fixedDeltaTime);
    }
}


