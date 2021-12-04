using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class SettingsMenu : MonoBehaviour
{   
    public int resIndex, volumeSetting, brightnessSetting, previousScene; 
    public TMP_Text resText;
    public Toggle fullScreen, vSync, antiAliasing;
    public Slider brightness, volume;
    public List<ResItem> resolutions = new List<ResItem>();


    private void Start() {
        for(int i = 0; i <= 7; i ++){
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical){
                resIndex = i;
                setResolution();
                break;
            }
        }

        setFullScreen();
        setVSync();
        setAntiAliasing();
        setVolume();
        setBrightness();
    }
    

    public void resLeft(){ //selects res options
        if (resIndex > 0){
            resIndex --;
        }
        setResolution();
    }

    public void resRight(){ //selects res options
        if (resIndex < 7){ 
            resIndex ++;
        }
        setResolution();
    }

    public void setResolution(){ //sets resolution
        resText.text = resolutions[resIndex].horizontal.ToString() + "x" + resolutions[resIndex].vertical.ToString();
        Screen.SetResolution(resolutions[resIndex].horizontal, resolutions[resIndex].vertical, fullScreen, 60);
    }

    public void setVSync(){
        if(vSync){
            QualitySettings.vSyncCount = 4;
        }
        else{
            QualitySettings.vSyncCount = 0;
        }
    }

    public void setAntiAliasing(){
        if(antiAliasing){
            QualitySettings.antiAliasing = 4;
        }
        else{
            QualitySettings.antiAliasing = 0;
        }
    }

    public void setFullScreen(){
        if(fullScreen){
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else{
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void setVolume(){
        
    }

    public void setBrightness(){
        Screen.brightness = brightness.value;
    }

    public void closeMenu(){
        SceneManager.LoadScene(previousScene);
    }
}

[System.Serializable]
public class ResItem{
    public int horizontal, vertical;
}