using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kosakata : MonoBehaviour {
    [SerializeField] string[] question = new string[] { "鸡", "猪", "公牛", "熊", "象", "仓鼠", "羊", "驴", "兔", "考拉" };
    [SerializeField] string[] jawabanbenar = new string[] { "1", "2", "1", "1", "3", "3", "1", "2", "2", "2" };

    public static string pilihjawaban;
    public static string pilihanditentukan = "n";
    public static int randQuestion = -1;

    public static int lives = 5;
    public static int score = 0;
    public static int soal = 0;
    [SerializeField] Text ScoreText;
    [SerializeField] Text soalIndex;

    // Use this for initialization
	void Start () {
        lives = 5;
        score = 0;
        soal = 0;
        //GetComponent<Text>().text = question[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (lives <= 0)
        {
            //pindah halaman or something?
        }
        soalIndex.text = soal.ToString();
        ScoreText.text = score.ToString();
        if (randQuestion == -1)
        {
            randQuestion = Random.Range(0, question.GetUpperBound(0));
            soal++;
            if (soal >= question.GetUpperBound(0) + 1)
            {
                //kalau sudah selesai soal
                PlayerPrefs.SetInt("KuisKata", 1);
                SceneManager.LoadScene("utama");
            }
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
