using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public void onButtonPress()
    {
        SceneManager.LoadScene(2);
    }
    
}
