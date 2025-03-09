using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class DATAGM : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] string fileLoad;
    [SerializeField] DatosPlayer data= new DatosPlayer();
    [SerializeField] Button BTNCargarDatos;
    private void Awake()
    {
        Time.timeScale = 1.0f;
        //DontDestroyOnLoad(this);
        fileLoad = Application.dataPath + "/DataPlayer.json";
        //LoadGame();
        BTNCargarDatos.interactable = (LoadGame());
    }
    [SerializeField]
   public bool LoadGame()
    {
        if(File.Exists(fileLoad))
        {
            string Info=File.ReadAllText(fileLoad);
            data=JsonUtility.FromJson<DatosPlayer>(Info);
            return true;
        }
        else
        {
            Debug.Log("No existe el archivo");
            return false;
        }
    }
    public void NewGame()
    {
            PlayerPrefs.SetInt("Vidas", 3);
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetString("Time", "0:0");
    
    }

    public void LoadingData()
    {
            Debug.Log(data);
            PlayerPrefs.SetInt("Vidas", data.vidas);
            PlayerPrefs.SetInt("Score", data.Score);
            PlayerPrefs.SetString("Time", data.Time);

    }

   
}
