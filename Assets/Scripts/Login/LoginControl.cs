using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginControl : MonoBehaviour {

    public Text id, password;
    public GameObject wrongText;

    public void OnClick()
    {
        if (id.text == "admin" && password.text == "*****")
        {
            wrongText.SetActive(false);
            SceneManager.LoadScene("AdminScene", LoadSceneMode.Additive);
        }
        else if (id.text == "parduotuve" && password.text == "*****")
        {
            wrongText.SetActive(false);
            SceneManager.LoadScene("ParduotuvesScene", LoadSceneMode.Additive);
        }
        else if (id.text == "tiekejas" && password.text == "*****")
        {
            wrongText.SetActive(false);
            SceneManager.LoadScene("TiekejoScene", LoadSceneMode.Additive);
        }
        else if (id.text == "vairuotojas" && password.text == "*****")
        {
            wrongText.SetActive(false);
            SceneManager.LoadScene("VairuotojoScene", LoadSceneMode.Additive);
        }
        else
        {
            wrongText.SetActive(true);
        }
    }
}
