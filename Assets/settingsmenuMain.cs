using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class settingsmenuMain : MonoBehaviour {

    public AudioMixer MainMixer;

    public void SetVolumemain(float volumemain){

        MainMixer.SetFloat("volumemain", volumemain);

    }

    public void SetFullscreenmain(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void SetQualitymain(int qualityIndex){

        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Backmain(){
        SceneManager.LoadScene("ui_start");
    }


}
