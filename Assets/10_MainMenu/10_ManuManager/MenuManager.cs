using System.Collections;
using System.Collections.Generic;
using MenuSound;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    
    void Start()
    {
        Sound.Manager.PlayMus((int)MusClip.MenuBkgMus);
    }

    public void SelectLevel(int level)
    {
        Settings.SetLevel(level);
        SceneManager.LoadScene(1);
    }
    
    
    
    
    
    
}
