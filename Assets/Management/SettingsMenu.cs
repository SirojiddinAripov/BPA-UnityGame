using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsMenu : MonoBehaviour
{   
    public int resIndex, volumeSetting, brightnessSetting; 
    public TMP_Text resText;
    public Toggle fullScreen, vSync, antiAliasing;
    public Slider brightness, volume;
    public List<ResItem> resolutions = new List<ResItem>();


    private void Start() {
        bool foundRes = false;
        for(int i = 0; i <= 7; i ++){
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical){
                foundRes = true;
                resIndex = i;
                setResolution();
            }
        }
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
}

[System.Serializable]
public class ResItem{
    public int horizontal, vertical;
}