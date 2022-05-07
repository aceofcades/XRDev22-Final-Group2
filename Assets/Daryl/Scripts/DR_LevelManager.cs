using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DR_LevelManager : MonoBehaviour
{
    private static DR_LevelManager instance;
    public static DR_LevelManager Instance {
        get { 
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private List<string> _objectRotationOk;

    public List<string> ObjectRotationOk
    {
        get { return _objectRotationOk; }        
    }

    public void AddObjectRotationOk(string itemToAdd)
    {
        if (!_objectRotationOk.Exists(item => item == itemToAdd)){
            _objectRotationOk.Add(itemToAdd);
        }
    }

    public void RemoveObjectRotationOk(string itemToRemove)
    {
        if (_objectRotationOk.Exists(item => item == itemToRemove)) { 
            _objectRotationOk.Remove(itemToRemove);
        }
    }

    public int ObjectRotationOkCount
    {
        get { return _objectRotationOk.Count; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _objectRotationOk = new List<string>();
    }
}
