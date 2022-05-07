using UnityEngine;
using UnityEngine.SceneManagement;

public class DR_TangramPiecesManager : MonoBehaviour
{
    public static DR_TangramPiecesManager currentTangramsCounter { get; private set; }
    private static int _numTangramsFound = 0;
   
    private void Awake()
    {
        currentTangramsCounter = this;
    }

    public static int NumTangramsFound
    {
        get { return _numTangramsFound; }
        private set { _numTangramsFound = value; }
    }

    public static void IncrementNumTangramsFound()
    {
        NumTangramsFound++;
        if (NumTangramsFound == 7)
        {
            DR_AudioManager.Instance.AudioPlayer.PlayOneShot(DR_AudioManager.Instance.LevelUpSoundEffect);
            SceneManager.LoadSceneAsync(3, LoadSceneMode.Single);
        }
    }
}
