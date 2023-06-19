using UnityEngine;

public class Cube8 : MonoBehaviour
{
    [SerializeField] private Cube16 _cube;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube8 cub))
        {
            Vector3 collisionPoint = collision.GetContact(0).point;

            collision.gameObject.SetActive(false);
            if (this.gameObject.activeSelf)
            {
                Instantiate(_cube, collisionPoint, Quaternion.identity);
            }
        }
    }
}
