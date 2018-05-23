using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTampilan : MonoBehaviour {
    [SerializeField] GameObject LiveImage;
    [SerializeField] float JarakAntar;
    private int live;
	// Use this for initialization
	void Start () {
        live = kosakata.lives;
        cetakLive();
	}
	
	// Update is called once per frame
	void Update () {
        if (live != kosakata.lives)
        {
            cetakLive();
            live = kosakata.lives;
        }
	}

    void cetakLive()
    {
        deleteHati();
        for (int i = 0; i < kosakata.lives; i++)
        {
            Vector3 positionNew = new Vector3(gameObject.transform.position.x + JarakAntar * i, gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject hati= Instantiate(LiveImage);
            //hati.transform.parent = gameObject.transform;
            //hati.transform.position = positionNew;

            hati.transform.SetParent(gameObject.transform);
            hati.transform.position = positionNew;
        }
    }
    void deleteHati()
    {
        GameObject[] hatis = GameObject.FindGameObjectsWithTag("Hati");
        foreach (GameObject gameObj in hatis)
        {
            Destroy(gameObj);
        }
    }

}
