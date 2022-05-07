using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DR_TangramIconsScript : MonoBehaviour
{
    [SerializeField]
    private Image myIcon;
   
    // Start is called before the first frame update
    void Start()
    {
        myIcon.color = new Color(1, 1, 1, 0.2f);
        
    }

    public void OnMyTangramFound()
    {
        myIcon.color = new Color(1, 1, 1, 1);
        this.gameObject.SetActive(false);
        DR_TangramPiecesManager.IncrementNumTangramsFound();        
    }
}
