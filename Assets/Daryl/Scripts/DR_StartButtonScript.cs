using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DR_StartButtonScript : MonoBehaviour
{
   
    public void OnButtonPress()
    {
        Debug.Log("Start Button Clicked.");
        //Scene cubeScene = SceneManager.GetSceneByPath("Assets/Feng Wu/Scene/Test03_VR.unity");
        //Debug.Log($"cubeScene.name is {cubeScene.name}");
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }
}
