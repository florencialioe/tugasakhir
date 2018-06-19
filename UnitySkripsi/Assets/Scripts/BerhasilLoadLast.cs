using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BerhasilLoadLast : MonoBehaviour
{
    public static JenisSoal jenisSoal;
    public static JenisHewan jenisHewan;
    public static KuisKe kuisKe;
    public static int scoreTerakhir;

    public Text teksResult;
	// Use this for initialization
	void Start ()
	{
        // gameObject
	    teksResult.text = "JenisSoal: " + jenisSoal + "\n" +
                   "JenisHewan: " + jenisHewan + "\n" +
                   "KuisKe: " + kuisKe + "\n" +
                   "scoreTerakhir: " + scoreTerakhir + "\n";

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
