using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class Popup_VoteController : Controller
{
    public const string POPUP_VOTE_SCENE_NAME = "Popup_Vote";

    public override string SceneName()
    {
        return POPUP_VOTE_SCENE_NAME;
    }

    public override void OnActive(object data)
    {
        base.OnActive(data);
    }

    public void Click()
    {
        Manager.Close();
    }

}