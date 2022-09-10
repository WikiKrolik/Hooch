using System.Collections;
using UnityEngine;

public class Alcohol : MonoBehaviour
{
    private AlcoholData _alcoholData; //TODO: Assign data to each alcohol at Start()
    private Vector3 _initialPosition;
    private Vector3 _targetPosition = new Vector3(4.86f, 0.45f, 0);
    private Vector3 _targetRotation = new Vector3(0, 0.0f, -90.0f * 9);
    private float speed = 100f;
    Vector3 _eulerAngleVelocity = new Vector3(0, 0, -83);

    private void Start()
    {
        _initialPosition = transform.position;
    }

    public IEnumerator Move()
    {
        while (transform.position != _targetPosition && transform.rotation.eulerAngles != _targetRotation)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime); ;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_targetRotation), speed * 5 * Time.deltaTime); ;
            yield return null;
        }
        

    }

    public IEnumerator MoveBack()
    {

        while (transform.position != _initialPosition && transform.rotation.eulerAngles != new Vector3(0.0f, 0.0f, 0.0f))
        {
            transform.position = Vector3.MoveTowards(transform.position, _initialPosition, speed * Time.deltaTime); ;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), speed * 5 * Time.deltaTime); ;
            yield return null;
        }
    }
}
