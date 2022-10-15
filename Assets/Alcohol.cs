using System.Collections;
using UnityEngine;

public class Alcohol : MonoBehaviour
{
    [Header("Main alcohol data")]
    public AlcoholData alcoholData; //TODO: Assign data to each alcohol at Start

    [Header("Shaker coordinates")]
    [SerializeField] private Vector3 targetPosition = new(4.36000013f,2.20000005f,0.1368424f);
    [SerializeField] private Quaternion targetRotation = Quaternion.Euler(0, 0.0f, -90.0f);
    
    [Header("Pouring animation")]
    [SerializeField] private float speed = 100f;

     private ParticleSystem ps;
    
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    public bool _animationPlaying;
    private bool _animationCancelled;


    private void Start()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;

        targetPosition = GameObject.FindWithTag("PartyMaker").transform.position + new Vector3(0,2,0);
        ps = GameObject.FindGameObjectWithTag("animation").GetComponent<ParticleSystem>();
        GameObject.FindGameObjectWithTag("animation").GetComponent<ParticleSystem>().enableEmission = false;
        //ps.main.startColor = alcoholData.fluidColor;

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().sprite  = alcoholData.sprite;
    }
    
    

    public IEnumerator Move()
    {
        var main = ps.main;
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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * 10 * Time.deltaTime); ;
            yield return null;
        }
        
        _animationPlaying = false;
        main.startColor = alcoholData.fluidColor;
        GameObject.FindGameObjectWithTag("animation").GetComponent<ParticleSystem>().enableEmission = true;
    }

    public IEnumerator MoveBack()
    {
        GameObject.FindGameObjectWithTag("animation").GetComponent<ParticleSystem>().enableEmission = false;

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
    }
}
