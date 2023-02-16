using UnityEngine;
using SS.View;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] Slider slider;
    private void Start()
    {
    }

    private void Update()
    {
        if(slider)
        {
            slider.value += Time.deltaTime;
            if (slider.value >= 1)
            {
                slider = null;
                //Manager.ShieldColor = new Color(0,0,0,30);
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetInt("Heart", 0);
                Manager.LoadingSceneName = LoadingController.LOADING_SCENE_NAME;
                Manager.Load(HomeController.HOME_SCENE_NAME);
            }
        }
    }

}
