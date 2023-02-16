using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class SettingsController : Controller
{
    public const string SETTINGS_SCENE_NAME = "Settings";

    public override string SceneName()
    {
        return SETTINGS_SCENE_NAME;
    }

    public override void OnActive(object data)
    {
        base.OnActive(data);
        Debug.Log(data);
    }


    public void Close()
    {
        Manager.Close();
    }
}