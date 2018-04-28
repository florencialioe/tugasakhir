using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[System.Serializable]

public class halbel
{
    public bool ba;
    public bool hom;
    public bool st;
    public bool belden;
    public bool belmen;
    public Sprite gmbrhwn;
    public string han;
    public string pin;
    public string ar;
    public Button rep;
    public Button ne;
    public Button kem;
}
public class CreateHalBel : MonoBehaviour {

    Scene newScene = SceneManager.CreateScene("My New Scene");

    public GameObject sampleisibel;
    public Transform contentPanel;
    public List<halbel> itemList;

	
}
