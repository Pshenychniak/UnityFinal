using UnityEngine;

public class Cube8 : MonoBehaviour
{
    [SerializeField] private Cube16 _cube;
    private int _nextValue;
    private Score _score;
    private void Start()
    {
        _nextValue = 16;
        _score = FindObjectOfType<Score>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube8 cub))
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
