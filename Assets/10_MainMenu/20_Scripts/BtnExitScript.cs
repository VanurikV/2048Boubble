using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BtnExitScript : MonoBehaviour
    {

        private GameControls _control;


        private void Awake()
        {
            _control = new GameControls();
            _control.Player.Quit.performed += context =>OnExit();
            
            //_control.Player.Quit.performed +=Quit;
        }

        private void OnEnable()
        {
            _control.Enable();
        }
        
        private void OnDisable()
        {
            _control.Disable();
        }

        public void OnExit()
        {
            Debug.Log("--QUIT--");
            _control.Disable();
            Application.Quit();
        }
    
        // public void Quit(InputAction.CallbackContext ctx)
        // {
        //     Debug.Log("--QUIT--");
        //     Application.Quit();
        // }
        
    }

