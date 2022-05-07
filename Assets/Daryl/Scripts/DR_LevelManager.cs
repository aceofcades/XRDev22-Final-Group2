using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DR_LevelManager : MonoBehaviour
{
    private List<MeshRenderer> _objectRotationOk;

    public List<MeshRenderer> ObjectRotationOk
    {
        get { return _objectRotationOk; }        
    }

    public void AddObjectRotationOk(MeshRenderer itemToAdd)
    {
        _objectRotationOk.Add(itemToAdd);
    }

    public void RemoveObjectRotationOk(MeshRenderer itemToRemove)
    {
        _objectRotationOk.Remove(itemToRemove);
    }

    public int ObjectRotationOkCount
    {
        get { return _objectRotationOk.Count; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _objectRotationOk = new List<MeshRenderer>();
    }
}
