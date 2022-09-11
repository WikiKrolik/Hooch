using System.Collections;
using UnityEngine;

public class Alcohol : MonoBehaviour
{
    [Header("Main alcohol data")]
    [SerializeField] private AlcoholData alcoholData; //TODO: Assign data to each alcohol at Start

    [Header("Shaker coordinates")]
    [SerializeField] private Vector3 targetPosition = new(4.86f, 0.45f, 0);
    [SerializeField] private Quaternion targetRotation = Quaternion.Euler(0, 0.0f, -90.0f);
    
    [Header("Pouring animation")]
    [SerializeField] private float speed = 100f;
    
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private bool _animationPlaying;
    private bool _animationCancelled;

    private void Start()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
    }

    public IEnumerator Move()
    {
        if (_animationPlaying)
        {
            _animationCancelled = true;
            yield return new WaitForEndOfFrame();
            _animationCancelled = false;
        }
        
        _animationPlaying = true;

        while ((transform.position != targetPosition || transform.rotation != targetRotation) && !_animationCancelled)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * 5 * Time.deltaTime); ;
            yield return null;
        }
        
        _animationPlaying = false;
        
        Debug.Log("Movement started");
    }

    public IEnumerator MoveBack()
    {
        if (_animationPlaying)
        {
            _animationCancelled = true;
            yield return new WaitForEndOfFrame();
            _animationCancelled = false;
        }

        _animationPlaying = true;
        while ((transform.position != _initialPosition || transform.rotation != _initialRotation) && !_animationCancelled)
        {
            transform.position = Vector3.MoveTowards(transform.position, _initialPosition, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _initialRotation, speed * 5 * Time.deltaTime); ;
            yield return null;
        }

        _animationPlaying = false;

        Debug.Log("Movement finished");
    }
}
