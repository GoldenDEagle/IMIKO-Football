using UnityEngine;

namespace Assets.Codebase.Gameplay
{
    public class Ball : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>())
            {
                Destroy(gameObject);
            }
        }
    }
}