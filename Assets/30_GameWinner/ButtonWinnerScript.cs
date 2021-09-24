using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonWinnerScript : MonoBehaviour
{
    public void onButtonWinnerPress()
    {
        SceneManager.LoadScene(0);
    }
}
