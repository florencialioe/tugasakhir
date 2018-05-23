using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kosakata : MonoBehaviour {
    List<string> question = new List<string>() { "鸡", "猪", "公牛", "熊", "象", "仓鼠", "羊", "驴", "兔", "考拉" };
    List<string> jawabanbenar = new List<string>() { "1", "2", "1", "1", "3", "3", "1", "2", "2", "2" };

    public static string pilihjawaban;
    public static string pilihanditentukan = "n";
    public static int randQuestion = -1;

    public static int lives = 5;
    public static int score = 0;
	// Use this for initialization
	void Start () {
        lives = 5;
        score = 0;
        //GetComponent<Text>().text = question[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (randQuestion == -1)
        {
            randQuestion = Random.Range(0, 10);
        }
        if (randQuestion>-1)
        {
            GetComponent<Text> ().text = question [randQuestion];
        }    
        //Debug.Log(question[randQuestion]);
        if (pilihanditentukan == "y")
        {
            pilihanditentukan = "n";

            if (jawabanbenar[randQuestion] == pilihjawaban)
            {
                Debug.Log("Correct!!" + "  " + randQuestion);
                score += 10;
                randQuestion = -1;
            }
            else {
                lives--;
            }
        }
	}
}
