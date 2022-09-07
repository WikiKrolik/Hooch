using UnityEngine;

public class Alcohol : MonoBehaviour
{
    private Vector3 _targetPosition;
    private float speed = 2f;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    public void Move(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(_targetPosition, position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f); 
    }
}
