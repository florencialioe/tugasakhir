using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class KuisDengarAir : MonoBehaviour
{
    [SerializeField] AudioClip[] question;
    [SerializeField] string[] jawabanbenar = new string[] { "1", "2", "1", "1", "3", "3", "1", "2", "2", "2" };


    public AudioSource SoundSoal;
    public static int score = 0;
    public static int soal = 0;
    [SerializeField] Text ScoreText;
    [SerializeField] Text soalIndex;
    public int tempSoal;
    // Use this for initialization
    void Start()
    {
        SoundSoal = GetComponent<AudioSource>();
        KuisKataAir.randQuestion = -1;
        KuisKataAir.lives = 5;
        score = 0;
        soal = 0;
        tempSoal = soal;
        //GetComponent<Text>().text = question[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (KuisKataAir.lives <= 0)
        {
            SceneManager.LoadScene("gagal");
            //pindah halaman or something?
        }
        soalIndex.text = soal.ToString();
        ScoreText.text = score.ToString();
        if (KuisKataAir.randQuestion == -1)
        {
            KuisKataAir.randQuestion = Random.Range(0, question.GetUpperBound(0));
            soal++;
            if (soal >= question.GetUpperBound(0) + 1)
            {
                //kalau sudah selesai soal
                PlayerPrefs.SetInt("KuisDengarAir", 1);
                SceneManager.LoadScene("berhasil");
            }
        }
        if (KuisKataAir.randQuestion > -1)
        {
            SoundSoal.clip = question[KuisKataAir.randQuestion];
            if (tempSoal != soal)
            {
                PlaySoal();
                tempSoal = soal;
            }
        }
        //Debug.Log(question[randQuestion]);
        if (KuisKataAir.pilihanditentukan == "y")
        {
            KuisKataAir.pilihanditentukan = "n";

            if (jawabanbenar[KuisKataAir.randQuestion] == KuisKataAir.pilihjawaban)
            {
                Debug.Log("Correct!!" + "  " + KuisKataAir.randQuestion);
                score += 10;
                KuisKataAir.randQuestion = -1;
            }
            else
            {

                KuisKataAir.lives--;
            }
        }


    }
    public void PlaySoal()
    {
        Debug.Log("Jalan");
        SoundSoal.Stop();
        SoundSoal.Play();
    }
}
