using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] AudioClip _moveClip , _loseClip;

    [SerializeField] private GamePlayManager _gm;
    [SerializeField] private GameObject _exprefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           SoundManager.Instance.PlaySound(_moveClip);
            _rotateSpeed *= -1;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0 ,0, _rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ob"))
        {
            SoundManager.Instance.PlaySound(_loseClip);
            Instantiate(_exprefab, transform.GetChild(0).position, Quaternion.identity);
            _gm.GameEnded();
            Destroy(gameObject);
            print("Game Over");
        }
    }
}
