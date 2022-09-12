using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class OptionsUIPanel : UIPanel
    {
        private GameManager gameManager;
        private UIManager uiManager;
        private GameSettings oldGameSettings;
        private GameSettings newGameSettings;

        private void Start()
        {
            gameManager = ServiceManager.i.GetManager<GameManager>();
            uiManager = ServiceManager.i.GetManager<UIManager>();
            oldGameSettings = ServiceManager.i.GetManager<GameManager>().GetGameSettings();
            newGameSettings = oldGameSettings;

            SetUI(oldGameSettings);
        }

        private void SetUI(GameSettings settings)
        {
            if (settings.fullScreen)
            {
                uiManager.GetItem<OptionsUIPanel, FullScreenUIItem>().
                    GetComponent<Button>().interactable = false;
            }
            else
            {
                uiManager.GetItem<OptionsUIPanel, WindowedUIItem>().
                    GetComponent<Button>().interactable = false;
            }

            string res = settings.resWidth + "x" + settings.resHeight;
            var resDrop = uiManager.GetItem<OptionsUIPanel, ResolutionUIItem>();
            var dropDown = resDrop.GetComponent<TMP_Dropdown>();
            switch(res)
            {
                case "1920x1080":
                    dropDown.value = 0;
                    break;
                case "1366x768":
                    dropDown.value = 1;
                    break;
                case "1280x800":
                    dropDown.value = 2;
                    break;
                case "1040x640":
                    dropDown.value = 3;
                    break;
                default:
                    Debug.Log("Error: Options Panel SetUI() resolution");
                    break;
            }

            var frame = settings.frameRate;
            var frameDrop = uiManager.GetItem<OptionsUIPanel, FrameRateUIItem>();
            var dropdown = frameDrop.GetComponent<TMP_Dropdown>();
            switch(frame)
            {
                case 30:
                    dropdown.value = 0;
                    break;
                case 60:
                    dropdown.value = 1;
                    break;
                case 75:
                    dropdown.value = 2;
                    break;
                case 120:
                    dropdown.value = 3;
                    break;
                case -1:
                    dropdown.value = 4;
                    break;
                default:
                    Debug.Log("Error: Options Panel SetUI() framerate");
                    break;
            }

            var valMaster = settings.masterVolume;
            var masterSlider = uiManager.GetItem<OptionsUIPanel, MasterSlider>();
            var masSlider = masterSlider.GetComponent<Slider>();
            masSlider.value = valMaster;

            var valUI = settings.UIVolume;
            var uiSlider = uiManager.GetItem<OptionsUIPanel, UISlider>();
            var uiS = uiSlider.GetComponent<Slider>();
            uiS.value = valUI;
        }

        //Graphics
        public void SetFullScreen()
        {
            newGameSettings.fullScreen = true;
            newGameSettings.windowed = false;
        }
        public void SetWindowed()
        {
            newGameSettings.fullScreen = false;
            newGameSettings.windowed = true;
        }
        public void SetRes(string newRes)
        {
            switch(newRes)
            {
                case "1040x640":
                    newGameSettings.resWidth = 1040;
                    newGameSettings.resHeight = 640;
                    break;
                case "1280x800":
                    newGameSettings.resWidth = 1280;
                    newGameSettings.resHeight = 800;
                    break;
                case "1366x768":
                    newGameSettings.resWidth = 1366;
                    newGameSettings.resHeight = 768;
                    break;
                case "1920x1080":
                    newGameSettings.resWidth = 1920;
                    newGameSettings.resHeight = 1080;
                    break;
            }
        }
        public void SetFrame(int newFrame)
        {
            switch(newFrame)
            {
                case 30:
                    newGameSettings.frameRate = 30;
                    break;
                case 60:
                    newGameSettings.frameRate = 60;
                    break;
                case 75:
                    newGameSettings.frameRate = 75;
                    break;
                case 120:
                    newGameSettings.frameRate = 120;
                    break;
                case -1:
                    newGameSettings.frameRate = -1;
                    break;
                default:
                    newGameSettings.frameRate = 30;
                    break;
            }
        }

        //Sounds
        public void SetMasterVol(int newVol)
        {
            newGameSettings.masterVolume = newVol;
        }
        public void SetUIVol(int newVol)
        {
            newGameSettings.UIVolume = newVol;
        }

        public void SaveSettings()
        {
            gameManager.SetGameSettings(newGameSettings);
            ClosePanel();
        }
    }
}