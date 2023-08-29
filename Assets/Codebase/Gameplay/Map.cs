using Assets.Codebase.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Gameplay
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private MapId _id;
        [SerializeField] private Transform _playerSpawnPosition;
        [SerializeField] private List<Transform> _ballSpawnPositions;

        public MapId Id => _id;
        public Transform PlayerSpawnPosition => _playerSpawnPosition;
        public List<Transform> BallSpawnPositions => _ballSpawnPositions;
    }
}