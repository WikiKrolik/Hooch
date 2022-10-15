using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    public float seconds;
    bool isSliderMoving;
    private IEnumerator coroutine;
    [SerializeField] private TextMeshProUGUI sliderText;

    private void Awake()
    {
        if (slider == null) slider = GetComponent<Slider>();
        coroutine = ChangingValue();
        //sliderText = GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator ChangingValue()
    {
        while (seconds  < 10)
        {
            slider.value += 0.01f;
            sliderText.GetComponent<TextMeshProUGUI>().text = (Mathf.RoundToInt(slider.value * 100)).ToString() + "%";
            seconds += 0.1f;
            yield return new WaitForSeconds(0.1f);
            Debug.Log(seconds);
        }
        if (seconds > 5)
        GameObject.FindGameObjectWithTag("animation").GetComponent<ParticleSystem>().enableEmission = false;

    }
    public void SliderMovement(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(coroutine);
        }
        else if (context.canceled)
        {
            StopCoroutine(coroutine);
            Debug.Log("Stopping");
        }

        /*while (context.started)
        {   
            StartCoroutine(ChangingValue());
        }
         if (context.canceled)
        {
            StopCoroutine(ChangingValue());
            
        }*/
    }
}
