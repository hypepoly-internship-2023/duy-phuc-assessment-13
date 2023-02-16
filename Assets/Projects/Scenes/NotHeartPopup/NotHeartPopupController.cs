using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class NotHeartPopupController : Controller
{
    public const string NOTHEARTPOPUP_SCENE_NAME = "NotHeartPopup";

    public override string SceneName()
    {
        return NOTHEARTPOPUP_SCENE_NAME;
    }

    public void Okay()
    {
        HomeController.home.AddingHeart(5);
        Manager.Close();
    }

    public void Refuse()
    {
        Manager.Close();
    }
}