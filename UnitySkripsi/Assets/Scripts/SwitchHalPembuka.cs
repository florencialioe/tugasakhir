using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchHalPembuka : MonoBehaviour
{
    public float delay;
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("halamanutama");
    }
}