using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class LevelsListView : View
{
    public HorizontalScrollSnap content;
    public GameObject pagination;
    public GameObject levelItem;
    public GameObject toggleItem;
    public GameObject listPageContainer;

    private int levelsOnPage = 24;
    private ArrayList pages;
    
    internal void Init()
    {
        Debug.Log("Level Scroll View init");
        pages = new ArrayList();
    }

    public void AddItems(List<LevelData> levelsData)
    {
        for (int i = 0; i < levelsData.Count; i++)
        {
            GameObject currentLevelItem = Instantiate(levelItem, Vector3.zero, Quaternion.identity);
            currentLevelItem.GetComponent<LevelsListItemView>().level = i + 1;
            int currentPage = i / levelsOnPage;
            currentLevelItem.transform.SetParent(getPage(currentPage).transform);
            currentLevelItem.transform.localScale = Vector3.one;
            currentLevelItem.transform.localPosition = Vector3.zero;
            var text = currentLevelItem.GetComponentInChildren<Text>();
            text.text = (i + 1).ToString();
        }
        for (int i = 0; i < pages.Count; i++)
        {
//            ((GameObject)pages[i]).transform.SetParent(content.transform);
            content.AddChild(((GameObject)pages[i]));
//            ((GameObject)pages[i]).transform.localScale = Vector3.one;
//            ((GameObject)pages[i]).transform.localPosition = Vector3.zero;
            GameObject currentToggleItem = Instantiate(toggleItem, Vector3.zero, Quaternion.identity);
            currentToggleItem.transform.SetParent(pagination.transform);
            currentToggleItem.transform.localScale = Vector3.one;
            currentToggleItem.transform.localPosition = Vector3.zero;
        }
    }

    private GameObject getPage(int pageNumber)
    {
        if (pages.Count <= pageNumber)
        {
            GameObject currentPageItem = Instantiate(listPageContainer, Vector3.zero, Quaternion.identity);
            pages.Add(currentPageItem);
        }
        return (GameObject)pages[pageNumber];
    }
}