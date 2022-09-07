using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
    private GameObject[] _alcohols;
    private GameObject _selected;

    private void Start()
    {
        _alcohols ??= GameObject.FindGameObjectsWithTag("Alcohol");
        _selected = _alcohols[0];

    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(context.ReadValue<Vector2>());
        }
    }

    private GameObject FindClosestAlcohol(Vector2 input)
    {
        float distance = float.MaxValue;
        GameObject result = null;
        foreach (GameObject alcohol in _alcohols)
        {
            //TODO Take input into consideration
            if (Vector3.Distance(alcohol.transform.position, _selected.transform.position) < distance)
            {
                result = alcohol;
            }
        }

        return result;
    }
}
