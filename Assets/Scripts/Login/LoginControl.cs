using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginControl : MonoBehaviour {

    public Text id, password;
    public GameObject wrongText;
    public GameObject noPass;
    public GameObject noLogin;
    public GameObject noLoginAndPass;

    public void OnClick()
    {


        if (id.text == "admin" && password.text == "*****")
        {
            wrongText.SetActive(false);
            noLoginAndPass.SetActive(false);
            noPass.SetActive(false);
            noLogin.SetActive(false);
            SceneManager.LoadScene("AdminScene", LoadSceneMode.Additive);
        }
        else if (id.text == "parduotuve" && password.text == "*****")
        {
            wrongText.SetActive(false);
            noLoginAndPass.SetActive(false);
            noPass.SetActive(false);
            noLogin.SetActive(false);
            SceneManager.LoadScene("ParduotuvesScene", LoadSceneMode.Additive);
        }
        else if (id.text == "tiekejas" && password.text == "*****")
        {
            wrongText.SetActive(false);
            noLoginAndPass.SetActive(false);
            noPass.SetActive(false);
            noLogin.SetActive(false);
            SceneManager.LoadScene("TiekejoScene", LoadSceneMode.Additive);
        }
        else if (id.text == "vairuotojas" && password.text == "*****")
        {
            wrongText.SetActive(false);
            noLoginAndPass.SetActive(false);
            noPass.SetActive(false);
            noLogin.SetActive(false);
            SceneManager.LoadScene("VairuotojoScene", LoadSceneMode.Additive);
        }
        else if (password.text == "" && id.text == "")
        {
            noLoginAndPass.SetActive(true);
            noPass.SetActive(false);
            noLogin.SetActive(false);
            wrongText.SetActive(false);

        }
        else if (password.text == "")
        {
            noLogin.SetActive(false);
            wrongText.SetActive(false);
            noLoginAndPass.SetActive(false);
            noPass.SetActive(true);
        }
        else if (id.text == "")
        {
            noLogin.SetActive(true);
            wrongText.SetActive(false);
            noLoginAndPass.SetActive(false);
            noPass.SetActive(false);
        }

        else
        {
            wrongText.SetActive(true);
            noLoginAndPass.SetActive(false);
            noPass.SetActive(false);
            noLogin.SetActive(false);
        }
    }
}
