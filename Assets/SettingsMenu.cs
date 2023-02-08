using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex){

        QualitySettings.SetQualityLevel(qualityIndex);
    }


}
