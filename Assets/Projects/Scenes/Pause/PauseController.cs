using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class PauseController : Controller
{
    public const string PAUSE_SCENE_NAME = "Pause";

    public override string SceneName()
    {
        return PAUSE_SCENE_NAME;
    }

    public void Resume()
    {
        Manager.Close();
        GameManager.instance.state = "PLAY";
    }

    public void Quit()
    {
        Manager.Load(HomeController.HOME_SCENE_NAME);
    }
}