using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;
using TMPro;
using UnityEngine.UI;

public class LevelController : Controller
{
    public const string LEVEL_SCENE_NAME = "Level";

    private int totalLevel = 30;

    [SerializeField] private GameObject levelItemPrefab,content;
    [SerializeField] private Sprite lockSprite;

    public override string SceneName()
    {
        return LEVEL_SCENE_NAME;
    }

    public override void OnActive(object data)
    {
        base.OnActive(data);
        for(int i = 0;i< totalLevel;i++)
        {
            GameObject newLevel = Instantiate(levelItemPrefab, content.transform);
            if(i==0)
            {
                newLevel.transform.GetChild(0).GetComponent<TMP_Text>().text = (i + 1).ToString();
                newLevel.GetComponent<Button>().onClick.AddListener(delegate { LevelClick(); });
            }
            else
            {
                newLevel.GetComponent<Image>().sprite = lockSprite;
                newLevel.transform.GetChild(0).GetComponent<TMP_Text>().text = string.Empty;
            }
        }
    }

    public void Click()
    {
        Manager.Close();
    }

    void LevelClick()
    {
        Manager.Load("Game");
    }

}