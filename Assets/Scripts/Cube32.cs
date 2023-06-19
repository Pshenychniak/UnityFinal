using UnityEngine;

public class Cube32 : MonoBehaviour
{
    [SerializeField] private Cube64 _cube;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube32 cub))
        {
            Vector3 collisionPoint = collision.GetContact(0).point;

            collision.gameObject.SetActive(false);
            if (this.gameObject.activeSelf)
            {
                print("this");
                Instantiate(_cube, collisionPoint, Quaternion.identity);
            }
        }
    }
}
