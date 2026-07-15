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
            PlayerPrefs.SetInt("Money", PlayerMoney.Instance.coinCount); // Sauvegarde le nombre de pièces du joueur
            PlayerPrefs.Save(); // Assurez-vous de sauvegarder les PlayerPrefs
        }
    }


    IEnumerator LoadLevelWithFade(string levelName)
    {
        yield return FadeManager.Instance.FadeOut();
        yield return SceneManager.LoadSceneAsync(levelName);
    }
}
