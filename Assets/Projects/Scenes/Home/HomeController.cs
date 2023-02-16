using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;
using TMPro;
public class HomeController : Controller
{
    public const string HOME_SCENE_NAME = "Home";

    [SerializeField] private TMP_Text heart;

    public static HomeController home;
    public override string SceneName()
    {
        return HOME_SCENE_NAME;
    }

    public override void OnActive(object data)
    {
        base.OnActive(data);
        if (home == null) { home = this; }
        heart.text = PlayerPrefs.GetInt("Heart").ToString();
    }

    public void AddingHeart(int number)
    {
        int curHeart = PlayerPrefs.GetInt("Heart");
        curHeart += number;
        PlayerPrefs.SetInt("Heart", curHeart);
        heart.text = PlayerPrefs.GetInt("Heart").ToString();
    }

    public void VoteClick()
    {
        Manager.Add(Popup_VoteController.POPUP_VOTE_SCENE_NAME);
    }

    public void SettingsClick()
    {
        Manager.Add(SettingsController.SETTINGS_SCENE_NAME);
    }

    public void PlayClick()
    {
        if(PlayerPrefs.GetInt("Heart") > 0)
        {
            Manager.Load("Game");
        }
        else
        {
            Manager.Add(NotHeartPopupController.NOTHEARTPOPUP_SCENE_NAME);
        }
        //Manager.Add(LevelController.LEVEL_SCENE_NAME);
    }
}