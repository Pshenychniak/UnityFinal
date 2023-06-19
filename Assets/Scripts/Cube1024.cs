using UnityEngine;

public class Cube1024 : MonoBehaviour
{
    [SerializeField] private Cube2048 _cube;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube1024 cub))
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
