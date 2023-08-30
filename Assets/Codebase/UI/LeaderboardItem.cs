using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.UI
{
    public class LeaderboardItem : MonoBehaviour
    {
        [SerializeField] private Image _placementImage;
        [SerializeField] private TMP_Text _placement;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _score;

        public void ConfigureItem()
        {

        }
    }
}