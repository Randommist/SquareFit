using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject endPanel;
    public List<Figure> Circles;
    public List<Figure> Squares;
    public List<Figure> Triangles;
    private Figure previousFiguraClick;
    private Figure nowFiguraClick;
    public void Start()
    {
        endPanel.SetActive(false);
        Figure[] figures;
        figures = GameObject.FindObjectsOfType<Figure>();
        for(int i = 0; i < figures.Length; i++)
        {
            if(figures[i].type == Figure.FigureType.circle)
                Circles.Add(figures[i]);
            if (figures[i].type == Figure.FigureType.square)
                Squares.Add(figures[i]);
            if (figures[i].type == Figure.FigureType.triangle)
                Triangles.Add(figures[i]);
        }
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D colliderUnderMouse = Physics2D.OverlapPoint(mousePosition, LayerMask.GetMask("Figures"));
        if (colliderUnderMouse != null)
        {
            if (colliderUnderMouse.GetComponent<Figure>() != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    FiguraClick(colliderUnderMouse.GetComponent<Figure>());
                }
            }
        }
    }

    public void FiguraClick(Figure figura)
    {
        previousFiguraClick = nowFiguraClick;
        nowFiguraClick = figura;

        if (previousFiguraClick != null)
        {
            if (previousFiguraClick.Size <= nowFiguraClick.Size)
            {
                if (previousFiguraClick.type == Figure.FigureType.square && nowFiguraClick.type == Figure.FigureType.circle)
                {
                    previousFiguraClick.gameObject.transform.position = nowFiguraClick.gameObject.transform.position;
                    Circles.Remove(nowFiguraClick);
                    Squares.Remove(previousFiguraClick);
                    DestroyImmediate(previousFiguraClick.GetComponent<Collider2D>());
                    DestroyImmediate(nowFiguraClick.GetComponent<Collider2D>());
                    PlayerData.SetScore(PlayerData.GetScore() + 1);
                }
            }

            if (previousFiguraClick.type == Figure.FigureType.triangle && nowFiguraClick.type == Figure.FigureType.square)
            {
                Triangles.Remove(previousFiguraClick);
                Destroy(previousFiguraClick.gameObject);
                nowFiguraClick.Size /= previousFiguraClick.Size/2;
                nowFiguraClick.Size = (nowFiguraClick.Size <= 0) ? 1 : nowFiguraClick.Size;
                PlayerData.SetScore(PlayerData.GetScore() + 1);
                PlayerData.SetEnergy(PlayerData.GetEnergy() - 1);
            }
        }

        bool checkLosse = true;
        foreach (Figure circle in Circles)
        {
            foreach (Figure square in Squares)
            {
                if(square.Size <= circle.Size)
                    checkLosse = false;
            }
        }
        if (Triangles.Count > 0)
            checkLosse = false;

        if (Circles.Count == 0)
        {
            Debug.Log("Win!");
            endPanel.SetActive(true);
            endPanel.GetComponentInChildren<Text>().text = "Win";
            endPanel.GetComponentInChildren<Text>().color = Color.green;
        }
        else if (checkLosse)
        {
            Debug.Log("Losse!");
            endPanel.SetActive(true);
            endPanel.GetComponentInChildren<Text>().text = "Losse";
            endPanel.GetComponentInChildren<Text>().color = Color.red;
        }

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
