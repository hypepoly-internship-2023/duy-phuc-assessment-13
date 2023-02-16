using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class ResultController : Controller
{
    public const string RESULT_SCENE_NAME = "Result";

    [SerializeField] private GameObject starsActive, starsUnactive;
    public override string SceneName()
    {
        return RESULT_SCENE_NAME;
    }

    public override void OnActive(object data)
    {
        base.OnActive(data);
        Debug.Log(data);
        if(data != null)
        {
            Debug.Log(data.ToString());
            if(data.ToString() == "False")
            {
                starsActive.SetActive(false);
                starsUnactive.SetActive(true);
            } else
            {
                starsActive.SetActive(true);
                starsUnactive.SetActive(false);
            }
        }
    }

    public void HomeClick()
    {
        Manager.Load(HomeController.HOME_SCENE_NAME);
    }

    public void VoteClick()
    {
        Manager.Load(Popup_VoteController.POPUP_VOTE_SCENE_NAME);
    }
}