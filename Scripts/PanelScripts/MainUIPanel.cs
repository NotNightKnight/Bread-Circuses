using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class MainUIPanel : UIPanel
    {
        private PlayUIPanel playUI;
        private OptionsUIPanel optionsUI;
        private LeaveUIPanel leaveUI;

        //private CinemachineVirtualCamera cam;

        //[SerializeField]
        //private float camMoveSpeed;
        //[SerializeField]
        //private float mArea;
        //[SerializeField]
        //private float limitLX;
        //[SerializeField]
        //private float limitRX;

        private void Start()
        {
            var uiManager = ServiceManager.i.GetManager<UIManager>();
            playUI = uiManager.GetPanel<PlayUIPanel>();
            optionsUI = uiManager.GetPanel<OptionsUIPanel>();
            leaveUI = uiManager.GetPanel<LeaveUIPanel>();

            //cam = uiManager.GetCamera();

            OpenPanel();
        }

        //private void Update()
        //{
        //    Vector2 mPos = Input.mousePosition;
        //    Vector2 max = new(Screen.width, Screen.height);

        //    if(mPos.x < mArea)
        //    {
        //        Vector3 newPos = cam.transform.position + (camMoveSpeed * Time.deltaTime * Vector3.left);
        //        if (newPos.x < limitLX)
        //            newPos.x = limitLX;
        //        cam.transform.position = newPos;
        //    }
        //    else if(mPos.x > (max.x-mArea))
        //    {
        //        Vector3 newPos = cam.transform.position + (camMoveSpeed * Time.deltaTime * Vector3.right);
        //        if (newPos.x > limitRX)
        //            newPos.x = limitRX;
        //        cam.transform.position = newPos;
        //    }
        //    else
        //    {
        //        Vector3 newPos = new(1.31f, -0.6f, -9.3f);
        //        cam.transform.DOMove(newPos, 0.3f);
        //    }
        //}

        public void PlayClick()
        {
            playUI.OpenPanel();
        }
        public void OptionsClick()
        {
            optionsUI.OpenPanel();
        }
        public void LeaveClick()
        {
            leaveUI.OpenPanel();
        }
    }
}