using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace NonKipple.Core
{
    public class GameManager : Service
    {
        [SerializeField]
        private GameSettings gameSettings;

        [SerializeField]
        private AudioMixer audioMixer;

        private bool onPause;

        public override IEnumerator Initialize()
        {
            Application.targetFrameRate = gameSettings.frameRate;

            var volMaster = gameSettings.masterVolume;
            var volUI = gameSettings.UIVolume;
            audioMixer.SetFloat("volMaster", volMaster);
            audioMixer.SetFloat("volUI", volUI);

            if (gameSettings.fullScreen)
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            else if (gameSettings.windowed)
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Screen.SetResolution(gameSettings.resWidth, gameSettings.resHeight, false);
            }

            yield return waitForEndOfFrame;
        }

        public GameSettings GetGameSettings()
        {
            return gameSettings;
        }
        public void SetGameSettings(GameSettings newSettings)
        {
            gameSettings = newSettings;
        }

        public void Pause()
        {
            onPause = true;
            Time.timeScale = 0;
        }
        public void Resume()
        {
            onPause = false;
            Time.timeScale = 1;
        }

        //Graphics
        public void SetScreenMode(string mode)
        {
            switch (mode)
            {
                case "fullScreen":
                    Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

                    gameSettings.fullScreen = true;
                    gameSettings.windowed = false;
                    break;
                case "windowed":
                    Screen.fullScreenMode = FullScreenMode.Windowed;

                    gameSettings.fullScreen = false;
                    gameSettings.windowed = true;
                    break;
                default:
                    Debug.Log("Error: Screen mode type is wrong: GameManager.cs");
                    break;
            }
            Debug.Log("ScreenMode changed to: " + mode);
        }
        public void SetFrameRate(int frameRate)
        {
            Application.targetFrameRate = frameRate;

            gameSettings.frameRate = frameRate;
            Debug.Log("Frame rate changed to: " + frameRate);
        }
        public void SetScreenRes(string res)
        {
            switch (res)
            {
                case "1040x640":
                    Screen.SetResolution(1040, 640, Screen.fullScreenMode);
                    break;
                case "1280x800":
                    Screen.SetResolution(1280, 800, Screen.fullScreenMode);
                    break;
                case "1366x768":
                    Screen.SetResolution(1366, 768, Screen.fullScreenMode);
                    break;
                case "1920x1080":
                    Screen.SetResolution(1920, 1080, Screen.fullScreenMode);
                    break;
                default:
                    Debug.Log("Error: Wrong screen res!");
                    break;
            }

            gameSettings.resWidth = Screen.currentResolution.width;
            gameSettings.resHeight = Screen.currentResolution.height;
            Debug.Log("Res changed to: " + res);
        }

        //Sound
        public void SetMasterVolume(int volume)
        {
            audioMixer.SetFloat("volMaster", volume);

            gameSettings.masterVolume = volume;
            Debug.Log("Volume Master changed to: " + volume);
        }
        public void SetUIVolume(int volume)
        {
            audioMixer.SetFloat("volUI", volume);

            gameSettings.UIVolume = volume;
            Debug.Log("Volume UI changed to: " + volume);
        }
    }
}