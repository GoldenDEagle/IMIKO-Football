﻿using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Codebase.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        [Tooltip("Boot speed")]
        [SerializeField] private float _speed = 2f;

        private float _verticalDirection;
        private float _horizontalDirection;
        private Vector2 _direction;
        private Rigidbody2D _rigidbody;
        private PlayerInput _input;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _input = GetComponent<PlayerInput>();
        }

        public void SetVerticalDirection(float value)
        {
            _verticalDirection = value;
        }

        public void SetHorizontalDirection(float value)
        {
            _horizontalDirection = value;
        }

        private void FixedUpdate()
        {
            _direction = new Vector2(_horizontalDirection, _verticalDirection);
            _rigidbody.velocity = _direction * _speed;
        }

        public void DisableInput()
        {
            _input.enabled = false;
        }
    }
}