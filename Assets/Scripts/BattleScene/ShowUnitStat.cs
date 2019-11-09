using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShowUnitStat : MonoBehaviour
{
    [SerializeField]
    protected GameObject unit;

    [SerializeField]
    private float maxValue;

    private Vector2 initialScale;
    private Vector3 initialPosition;

    private void Start()
    {
        initialScale = gameObject.transform.localScale;
        initialPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (unit)
        {
            float newValue = 0;
            if (NewStatValue() > 0)
            {
                newValue = NewStatValue();
            }            
            float newScale = (initialScale.x * newValue) / maxValue;
            gameObject.transform.localScale = new Vector2(newScale, initialScale.y);
            gameObject.transform.position = initialPosition;
        }
    }

    public void ChangeUnit(GameObject newUnit)
    {
        unit = newUnit;
    }

    abstract protected float NewStatValue();
}
