using UnityEngine;

namespace Assets.Codebase.UI.Windows
{
    public class BaseWindow : MonoBehaviour
    {
        protected void CloseWindow()
        {
            Destroy(gameObject);
        }
    }
}