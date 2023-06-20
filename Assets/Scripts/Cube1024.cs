using UnityEngine;

public class Cube1024 : MonoBehaviour
{
    [SerializeField] private Cube2048 _cube;
    private int _nextValue;
    private Score _score;
    private void Start()
    {
        if(this.gameObject.TryGetComponent(out Rigidbody rigid))
        {
            rigid.AddRelativeForce(Random.Range(0,3), Random.Range(0,3), Random.Range(0,3), ForceMode.Impulse);
        }
        _nextValue = 2048;
        _score = FindObjectOfType<Score>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube1024 cub))
        {
            Vector3 collisionPoint = collision.GetContact(0).point;

            collision.gameObject.SetActive(false);
            if (this.gameObject.activeSelf)
            {
                _score.AddScore(_nextValue);
                Instantiate(_cube, collisionPoint, Quaternion.identity);
            }
        }
    }
}
