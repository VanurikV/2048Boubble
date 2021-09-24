using UnityEngine;

namespace Client
{
    sealed partial class InitAllSystem
    {
        //Размер в пикселях для отображения * targetAspect
        private float HalfLenSize = 2560+128;//720*0.5625f; 


        private Camera _camera=Camera.main;
        
        private float _previousAspect;
        private float unitsPerPixel;

        
        
        private void SetupCamera()
        {

            HalfLenSize = _global.CurField.Dx*Const.CellSize + 128;
            
            _camera.orthographicSize = Mathf.Round(HalfLenSize / _camera.aspect/2);
            _camera.transform.position = new Vector3(_camera.aspect * _camera.orthographicSize, -_camera.orthographicSize, -10);
            
            
            Debug.Log("--Camera resize-- " + Camera.main.aspect);
            
        }
            
            
            
        }
    }
