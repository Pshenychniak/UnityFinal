using UnityEngine;

public class Cube4 : MonoBehaviour
{
    [SerializeField] private Cube8 _cube;
    [SerializeField] private Score _score;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube4 cub))
        {
            Vector3 collisionPoint = collision.GetContact(0).point;

            collision.gameObject.SetActive(false);
            if (this.gameObject.activeSelf)
            {
                //_score.Value += 8;
                Instantiate(_cube, collisionPoint, Quaternion.identity);
            }
        }
    }
}
