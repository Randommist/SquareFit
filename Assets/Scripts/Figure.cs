using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class Figure : MonoBehaviour
{
    public enum FigureType
    {
        circle,
        square,
        triangle
    }

    public int Size = 10;
    public FigureType type;
    private float multiplierSize = 0.1f;

    void Update()
    {
        switch (type)
        {
            case FigureType.circle:
                transform.localScale = new Vector3(Size * multiplierSize, Size * multiplierSize, 1);
                break;
            case FigureType.square:
                transform.localScale = new Vector3(Size / (Mathf.Sqrt(2)) * multiplierSize, Size / (Mathf.Sqrt(2)) * multiplierSize, 1);
                break;
            case FigureType.triangle:
                transform.localScale = new Vector3(Size * multiplierSize, Size * multiplierSize, 1);
                break;
        }
        
    }
}
