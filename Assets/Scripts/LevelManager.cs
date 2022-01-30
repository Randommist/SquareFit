using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject LevelGroupPrefab;
    public GameObject ScrollViewContent;
    [Header("Set Level Group Count")]
    public int LevelsGroupCount;
    public float Offset;
    public float SnapSpeed;

    private GameObject[] levelGroups;
    private RectTransform contentRectTransform;
    public int selectedGroupId;
    private bool isScrolling = false;
    public static void LoadLevel(int num)
    {
        SceneManager.LoadScene(num);
    }

    [ContextMenu("Update level groups")]
    public void UpdateLevelGroup()
    {
        if (LevelGroupPrefab != null && ScrollViewContent != null)
        {
            levelGroups = new GameObject[LevelsGroupCount];
            for (int i = ScrollViewContent.transform.childCount; i > levelGroups.Length; i--)
            {
                DestroyImmediate(ScrollViewContent.transform.GetChild(i-1).gameObject);
            }

            if (ScrollViewContent.transform.childCount < levelGroups.Length)
            {
                for (int i = ScrollViewContent.transform.childCount; i < levelGroups.Length; i++)
                {
                    GameObject instance = Instantiate(LevelGroupPrefab, ScrollViewContent.transform, false);
                    levelGroups[i] = instance;
                    instance.transform.localPosition = new Vector2(i*(LevelGroupPrefab.GetComponent<RectTransform>().sizeDelta.x+Offset), 0);

                }
            }
        }
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
    }
    private void Start()
    {
        levelGroups = new GameObject[ScrollViewContent.transform.childCount];
        for (int i = 0; i < ScrollViewContent.transform.childCount; i++)
        {
            levelGroups[i] = ScrollViewContent.transform.GetChild(i).gameObject;
        }
        contentRectTransform = ScrollViewContent.GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        float nearestPos = float.MaxValue;
        for(int i = 0; i < levelGroups.Length; i++)
        {
            float distance = Mathf.Abs(contentRectTransform.anchoredPosition.x + levelGroups[i].transform.localPosition.x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedGroupId = i;
            }
        }
        if (!isScrolling)
        {
            contentRectTransform.anchoredPosition = new Vector2(Mathf.SmoothStep(contentRectTransform.anchoredPosition.x, -levelGroups[selectedGroupId].transform.localPosition.x, SnapSpeed*Time.fixedDeltaTime),
                        contentRectTransform.anchoredPosition.y);
        }
        

    }
}
