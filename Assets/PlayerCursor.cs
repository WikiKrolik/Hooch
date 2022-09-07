using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
    private GameObject[] _alcohols;
    private GameObject _selected;

    private void Start()
    {
        if( _alcohols == null)
            _alcohols = GameObject.FindGameObjectsWithTag("Alcohol");
        _selected = _alcohols[0];
        _selected.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _selected.GetComponent<SpriteRenderer>().color = Color.white;
            _selected = FindClosestAlcohol(context.ReadValue<Vector2>());
            _selected.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private GameObject FindClosestAlcohol(Vector2 input)
    {
        float distance = float.MaxValue;
        GameObject result = null;
        foreach (GameObject alcohol in _alcohols)
        {
            if (alcohol == _selected) continue;

            Vector2 vectorSelected = new Vector2(_selected.transform.position.x, _selected.transform.position.y);
            Vector2 vectorAlcohol = new Vector2(alcohol.transform.position.x, alcohol.transform.position.y);

            if (Vector2.Angle(vectorAlcohol - vectorSelected, input) > 45) continue;


            float x = Vector3.Distance(alcohol.transform.position, _selected.transform.position);
            if (x < distance)
            {
                result = alcohol;
                distance = x;
            }
        }
        if(result == null) return _selected;
        return result;
    }
}
