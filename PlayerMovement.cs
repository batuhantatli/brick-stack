using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesMrkt.MissionFloor
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] float _movSpeed;
        [SerializeField] float _dirSpeed;

        [SerializeField] DynamicJoystick _joystick;
        [SerializeField] Animator animator;
        void Update()
        {
            Move(_joystick.Direction);
        }

        Vector3 velocity;
        public void Move(Vector2 input)
        {
            if (input == Vector2.zero)
            {
                animator.SetBool("Running", false);
                return;
            }

            animator.SetBool("Running", true);

            velocity.Set(input.x, 0, input.y);

            transform.position += velocity * _movSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(velocity, Vector3.up),
                _dirSpeed * Time.deltaTime);
        }

    }

}