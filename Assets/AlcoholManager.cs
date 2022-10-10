using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholManager : MonoBehaviour
{
    [SerializeField] private GameObject alcohol;
    void Awake()
    {
        Object[] alcohols = Resources.LoadAll("AlcoholScriptable/", typeof(AlcoholData));

        Debug.Log(alcohols);
        
        int num = 0;
        foreach (AlcoholData data in alcohols)
        {
            GameObject alcohol = Instantiate(this.alcohol, new Vector3(-10f + num, 4.5f, 0), Quaternion.identity);
            alcohol.GetComponent<Alcohol>().alcoholData = data;
            num += 2;
        }
    }
}
