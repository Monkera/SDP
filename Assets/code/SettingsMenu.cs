using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer MainMixer;

    public void SetVolume(float volume){

        MainMixer.SetFloat("volume", volume);

    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex){

        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Back(){
        SceneManager.LoadScene("pausedmenu");
    }


}