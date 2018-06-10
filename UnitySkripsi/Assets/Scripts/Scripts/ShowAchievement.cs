using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAchievement : MonoBehaviour
{
    public Text textAchievement;
    [SerializeField]  Button[] AchivementShow; // sementara ada 9. 0-2 Dengar, 3-5 Gurat, 6-8 Kosakata
    [SerializeField] Text GuratanShow;
    [SerializeField] Text KosakataShow;
    [SerializeField] Text MendengarShow; 

    // Use this for initialization
	void Start ()
	{
        //PlayerPrefs.DeleteAll();
        //textAchievement = GetComponent<Text>();
        textAchievement.text = AchievementManager.CreateConfig();
	    //int[] pararel = AchievementManager.ToGetAchivement();
       // Debug.Log(pararel[0]+" "+pararel[1]+" "+pararel[2]) ;
       summonAchivment();
        giveText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void giveText()
    {
        int[] value = AchievementManager.ToGetHowManyAchivement();
        MendengarShow.text = "Current Quiz : " + value[0].ToString();
        GuratanShow.text= "Current Quiz : " + value[1].ToString();
        KosakataShow.text= "Current Quiz : " + value[2].ToString();
    }

    void summonAchivment()
    {
        int[] AScore = AchievementManager.ToGetAchivement();
        Debug.Log(AScore[0] + " " + AScore[1] + " " + AScore[2]);
        //Show Mendengar
        for (int i = 0; i < 3; i++)
        {
            if (AScore[0] >= i && AScore[0]!=0)
            {
                AchivementShow[i].interactable = true;
            }
            else
            {
                AchivementShow[i].interactable = false;
            }
        }
        //Show Guratan
        for (int i = 0; i < 3; i++)
        {
            if (AScore[1] >= i && AScore[1] != 0)
            {
                AchivementShow[i+3].interactable = true;
            }
            else
            {
                AchivementShow[i+3].interactable = false;
            }
        }

        //Show KosaKata
        for (int i = 0; i < 3; i++)
        {
            if (AScore[2] >= i&& AScore[2] != 0)
            {
                AchivementShow[i + 6].interactable = true;
            }
            else
            {
                AchivementShow[i + 6].interactable = false;
            }
        }
    }
}
