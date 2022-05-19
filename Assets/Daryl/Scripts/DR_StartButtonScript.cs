using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DR_StartButtonScript : MonoBehaviour
{
   
    public void OnButtonPress()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
}
