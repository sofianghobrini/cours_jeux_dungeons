using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    public string levelName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadLevelWithFade(levelName));
        }
    }


    IEnumerator LoadLevelWithFade(string levelName)
    {
        yield return FadeManager.Instance.FadeOut();
        yield return SceneManager.LoadSceneAsync(levelName);
    }
}
