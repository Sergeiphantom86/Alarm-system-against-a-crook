using UnityEngine;

public class Rogue : MonoBehaviour
{
    private Vector3 _direction;
    private bool _leftmostPoint;
    private float _startingPosition;

    private void Start()
    {
        _startingPosition = transform.position.z;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float speed = 0.02f;
        float lengthOfMovement = 8;

        if (_leftmostPoint)
        {
            MoveInOneDirection(-speed);

            if (transform.position.z <= _startingPosition)
            {
                _leftmostPoint = false;
            }
        }
        else if (_leftmostPoint == false)
        {
            MoveInOneDirection(speed);

            if (transform.position.z >= _startingPosition + lengthOfMovement)
            {
                _leftmostPoint = true;
            }
        }
    }

    private void MoveInOneDirection(float speed)
    {
        _direction.z = speed;

        transform.Translate(_direction);
    }
}