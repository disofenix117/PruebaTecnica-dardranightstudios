using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveGame : MonoBehaviour
{

    public DatosPlayer data = new DatosPlayer();
    [SerializeField] string fileLoad;
    [SerializeField] HUD hud = new HUD();
    private void Awake()
    {
        hud=FindObjectOfType<HUD>();
        fileLoad = Application.dataPath + "/DataPlayer.json";

    }
    [SerializeField]
    public void Saving()
    {
        DatosPlayer NewInfo = new DatosPlayer()
        {
            vidas = hud.Lives,
            Score = hud.Score,
        };
        string toJSON = JsonUtility.ToJson(NewInfo);
        File.WriteAllText(fileLoad, toJSON);
    }
}
