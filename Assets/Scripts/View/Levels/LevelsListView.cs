using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class LevelsListView : View
{
    public GridLayoutGroup content;
    public GameObject item;
    
    internal void Init()
    {
        Debug.Log("Level Scroll View init");
    }

    public void AddItems(List<LevelData> levelsData)
    {
        for (int i = 0; i < levelsData.Count; i++)
        {
            GameObject instance = Instantiate(item, Vector3.zero, Quaternion.identity);
            instance.GetComponent<LevelsListItemView>().level = i + 1;
            instance.transform.SetParent(content.transform);
            instance.transform.localScale = Vector3.one;
            instance.transform.localPosition = Vector3.zero;
            var text = instance.GetComponentInChildren<Text>();
            text.text = (i + 1).ToString();
        }
    }
}