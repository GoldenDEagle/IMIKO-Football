using Assets.Codebase.Data;
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

        public void ConfigureItem(PlayerResult playerResult, int placement)
        {
            _name.text = playerResult.PlayerName;
            _score.text = playerResult.Score.ToString();
            _placement.text = placement.ToString();
        }
    }
}