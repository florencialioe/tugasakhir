using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KuisGambarAir : MonoBehaviour
{
    public KuisKe kuisKe;
    public JenisSoal jenisSoal;
    public JenisHewan jenisHewan;
    [SerializeField] Sprite[] question;
    [SerializeField] string[] jawabanbenar = new string[] { "1", "2", "1", "1", "3", "3", "1", "2", "2", "2" };



    public static int score = 0;
    public static int soal = 0;
    [SerializeField] Text ScoreText;
    [SerializeField] Text soalIndex;

    // Use this for initialization
    void Start()
    {
        KuisKataAir.randQuestion = -1;
        KuisKataAir.lives = 5;
        score = 0;
        soal = 0;
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
                PlayerPrefs.SetInt("KuisGambarAir", 1);
                 
                BerhasilLoadLast.jenisSoal = jenisSoal;
                BerhasilLoadLast.jenisHewan = jenisHewan;
                BerhasilLoadLast.kuisKe = kuisKe;
                BerhasilLoadLast.scoreTerakhir = score;

                var am = new AchievementManager(jenisSoal, jenisHewan, kuisKe);
                am.count += 1;
                am.totalStar(); // jumlah bintang yg dia dapatkan
                am.Save();

                var pm = new ProgressManager();
                pm.Complete(jenisSoal, jenisHewan, kuisKe);
                pm.Save();

                SceneManager.LoadScene("berhasil");
            }
        }
        if (KuisKataAir.randQuestion > -1)
        {
            GetComponent<Image>().sprite = question[KuisKataAir.randQuestion];
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
}
