using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private Cube _cube;
    [SerializeField] private Cube4 _cube4;
    [SerializeField] private Transform _cubeSpawnPoint;
    [SerializeField] private Score _score;
    private bool _isGrounded = false;  
    private bool _isMoveble = true;


    private void Update()
    {
        if (_isMoveble)
        {
            var horizontal = Input.GetAxis("Horizontal");
            var horisontalSpeed = horizontal * Time.deltaTime * _speed;

            if (_isGrounded)
            {
                _rigidbody.AddRelativeForce(horisontalSpeed, 0f, 0f, ForceMode.Impulse);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _rigidbody.AddRelativeForce(0f, 0f, 20, ForceMode.Impulse);
                    _isMoveble = false;
                    SpawnCube();
                }
            }
        }        
    }
    private void SpawnCube()
    {
        _score.Value+=2;
        Instantiate(_cube, _cubeSpawnPoint.position, _cube.transform.rotation);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cub))
        {
            Vector3 collisionPoint = collision.GetContact(0).point;

            collision.gameObject.SetActive(false);
            if (this.gameObject.activeSelf)
            {
                _score.Value+=4;
                Instantiate(_cube4, collisionPoint, Quaternion.identity);
            }
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            _isGrounded = true;
        }

    }
    public void SpawnNextCube(Vector3 position,Quaternion rotation)
    {
            Instantiate(_cube4, position, rotation);  
    }
}
