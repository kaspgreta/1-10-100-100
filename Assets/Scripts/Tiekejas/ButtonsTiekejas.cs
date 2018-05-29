using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsTiekejas : MonoBehaviour
{
    public GameObject infoPanel, pranesimoPanel;
    public GameObject errorMessage, errorZinomiMessage, errorNaujiMessage;
    public GameObject pranesimoText, sekmingaiText;
    public Text uzsakymoIdPranesimui;
    public GameObject uzsakymas, uzsakymasNew;
    public GameObject content, contentNew;
    public GameObject toggle, toggleNew;

    List<GameObject> uzsakymoPavadinimas = new List<GameObject>();
    List<GameObject> uzsakymoKiekis = new List<GameObject>();
    List<GameObject> uzsakymoPrio = new List<GameObject>();
    List<GameObject> uzsakymoCheckBox = new List<GameObject>();

    List<GameObject> uzsakymoPavadinimasNew = new List<GameObject>();
    List<GameObject> uzsakymoKiekisNew = new List<GameObject>();
    List<GameObject> uzsakymoPrioNew = new List<GameObject>();
    List<GameObject> uzsakymoCheckBoxNew = new List<GameObject>();

    void Start()
    {
        GameObject s;
        for (int i = 0; i < 14; i++)
        {
            s = Instantiate(uzsakymasNew);
            s.transform.SetParent(contentNew.transform, false);
            s.GetComponent<RectTransform>().position = new Vector3(s.transform.position.x, -i, 0);
            s.name = "uzsakymasNew" + i.ToString();
            s.transform.GetChild(0).GetComponent<Text>().text = "Naujas uzsakymas numeris"+i.ToString();

            uzsakymoPavadinimasNew.Add(s.transform.GetChild(0).gameObject);
            uzsakymoKiekisNew.Add(s.transform.GetChild(1).gameObject);
            uzsakymoPrioNew.Add(s.transform.GetChild(2).gameObject);
            uzsakymoCheckBoxNew.Add(s.transform.GetChild(3).gameObject);      
        }
        for (int i = 0; i < 6; i++)
        {
            s = Instantiate(uzsakymas);
            s.transform.SetParent(content.transform, false);
            s.GetComponent<Transform>().position = new Vector3(s.transform.position.x, -i, 0);
            s.name = "uzsakymas" + i.ToString();
            s.transform.GetChild(0).GetComponent<Text>().text = "uzsakymas numeris"+i.ToString();

            uzsakymoPavadinimas.Add(s.transform.GetChild(0).gameObject);
            uzsakymoKiekis.Add(s.transform.GetChild(1).gameObject);
            uzsakymoPrio.Add(s.transform.GetChild(2).gameObject);
            uzsakymoCheckBox.Add(s.transform.GetChild(3).gameObject);
          
        }
    } // Testiniai duomenys

    void Update()
    {

    }

    public void PazymetiVisas()
    {
        if (toggle.GetComponent<Toggle>().isOn)
        {
            for (int i = 0; i < uzsakymoPavadinimas.Count; i++)
            {
                uzsakymoCheckBox[i].GetComponent<Toggle>().isOn = true;
                toggle.transform.GetChild(1).GetComponent<Text>().text = "Atžymėti visus užsakymus";
            }
        }
        else
        {
            for (int i = 0; i < uzsakymoPavadinimas.Count; i++)
            {
                uzsakymoCheckBox[i].GetComponent<Toggle>().isOn = false;
                toggle.transform.GetChild(1).GetComponent<Text>().text = "Pažymėti visus užsakymus";
            }

        }
    }

    public void PazymetiVisasNew()
    {
        if (toggleNew.GetComponent<Toggle>().isOn)
        {
            for (int i = 0; i < uzsakymoPavadinimasNew.Count; i++)
            {
                uzsakymoCheckBoxNew[i].GetComponent<Toggle>().isOn = true;
                toggleNew.transform.GetChild(1).GetComponent<Text>().text = "Atžymėti visus naujus užsakymus";
            }
        }
        else
        {
            for (int i = 0; i < uzsakymoPavadinimasNew.Count; i++)
            {
                uzsakymoCheckBoxNew[i].GetComponent<Toggle>().isOn = false;
                toggleNew.transform.GetChild(1).GetComponent<Text>().text = "Pažymėti visus naujus užsakymus";
            }

        }
    }

    public void InfoPanelClose()
    {
        infoPanel.SetActive(false);
    }

    public void InfoPanelOpen()
    {
        infoPanel.SetActive(true);
    }

    public void IssiustiPranesima() // taip pat išsiųsti pranešimą į kitas scenas [parduotuvei ir admin]
    {
        if (pranesimoText.GetComponent<InputField>().text == "")
        {
            errorMessage.SetActive(true);
            StartCoroutine(TextDisable(errorMessage));
        }
        else
        {
            pranesimoText.GetComponent<InputField>().text = "";
            errorMessage.SetActive(false);
            pranesimoPanel.SetActive(false);
        }
    }

    public void PranesimoPanelOpen()
    {
        bool check = false;
        errorMessage.SetActive(false);
        int count = 1;
        uzsakymoIdPranesimui.text = "";
        for (int i = 0; i < uzsakymoPavadinimas.Count; i++)
        {
            if (uzsakymoCheckBox[i].GetComponent<Toggle>().isOn)
            {
                uzsakymoIdPranesimui.text += count.ToString() + ". ";
                uzsakymoIdPranesimui.text += uzsakymoPavadinimas[i].GetComponent<Text>().text;
                uzsakymoIdPranesimui.text += " ";
                count++;
                check = true;
            }
        }
        if (check)
        {
            errorZinomiMessage.SetActive(false);
            pranesimoPanel.SetActive(true);
        }
        else
        {
            errorZinomiMessage.SetActive(true);
            StartCoroutine(TextDisable(errorZinomiMessage));
        }
    }

    public void AtnaujintiUzsakymus() //Atnaujinti tiekejo užsakymus!!!
    {
        sekmingaiText.SetActive(true);
        StartCoroutine(TextDisable(sekmingaiText));
    }

    private IEnumerator TextDisable(GameObject text)
    {
        yield return new WaitForSeconds(3);
        text.SetActive(false);
    }

    public void PatvirtintiIssiuntima() //Perduoti informaciją
    {
        bool check = false;
        for (int i = uzsakymoPavadinimas.Count - 1; i >= 0; i--)
        {
            if (uzsakymoCheckBox[i].GetComponent<Toggle>().isOn)
            {
                for (int j = uzsakymoPavadinimas.Count - 1; j > i; j--)
                {
                    uzsakymoPavadinimas[j].transform.position = new Vector3(uzsakymoPavadinimas[j - 1].transform.position.x, uzsakymoPavadinimas[j - 1].transform.position.y, 0);
                    uzsakymoKiekis[j].transform.position = new Vector3(uzsakymoKiekis[j - 1].transform.position.x, uzsakymoKiekis[j - 1].transform.position.y, 0);
                    uzsakymoPrio[j].transform.position = new Vector3(uzsakymoPrio[j - 1].transform.position.x, uzsakymoPrio[j - 1].transform.position.y, 0);
                    uzsakymoCheckBox[j].transform.position = new Vector3(uzsakymoCheckBox[j - 1].transform.position.x, uzsakymoCheckBox[j - 1].transform.position.y, 0);
                }
                Destroy(uzsakymoPavadinimas[i].transform.parent.gameObject);
                uzsakymoPavadinimas.RemoveAt(i);
                uzsakymoKiekis.RemoveAt(i);
                uzsakymoPrio.RemoveAt(i);
                uzsakymoCheckBox.RemoveAt(i);
                check = true;
            }
        }
        if (check)
        {
            errorZinomiMessage.SetActive(false);
            errorNaujiMessage.SetActive(false);
        }
        else
        {
            errorZinomiMessage.SetActive(true);
            errorNaujiMessage.SetActive(false);
            StartCoroutine(TextDisable(errorZinomiMessage));
        }
    }

    public void PatvirtintiNaujusUzsakymus() //Perduoti informaciją
    {
        bool check = false;
        for (int i = uzsakymoPavadinimasNew.Count - 1; i >= 0; i--)
        {
            if (uzsakymoCheckBoxNew[i].GetComponent<Toggle>().isOn)
            {
                for (int j = uzsakymoPavadinimasNew.Count - 1; j > i; j--)
                {
                    uzsakymoPavadinimasNew[j].transform.position = new Vector3(uzsakymoPavadinimasNew[j-1].transform.position.x, uzsakymoPavadinimasNew[j-1].transform.position.y, 0);
                    uzsakymoKiekisNew[j].transform.position = new Vector3(uzsakymoKiekisNew[j - 1].transform.position.x, uzsakymoKiekisNew[j - 1].transform.position.y, 0);
                    uzsakymoPrioNew[j].transform.position = new Vector3(uzsakymoPrioNew[j - 1].transform.position.x, uzsakymoPrioNew[j - 1].transform.position.y, 0);
                    uzsakymoCheckBoxNew[j].transform.position = new Vector3(uzsakymoCheckBoxNew[j-1].transform.position.x, uzsakymoCheckBoxNew[j-1].transform.position.y, 0);
                }
                uzsakymoPavadinimasNew[i].transform.parent.SetParent(content.transform, false);
                uzsakymoPavadinimasNew[i].transform.position = new Vector3(uzsakymoPavadinimas[uzsakymoPavadinimas.Count - 1].transform.position.x, uzsakymoPavadinimas[uzsakymoPavadinimas.Count - 1].transform.position.y - 1, 0);
                uzsakymoPavadinimas.Add(uzsakymoPavadinimasNew[i]);
                uzsakymoKiekisNew[i].transform.position = new Vector3(uzsakymoKiekis[uzsakymoKiekis.Count - 1].transform.position.x, uzsakymoKiekis[uzsakymoKiekis.Count - 1].transform.position.y - 1, 0);
                uzsakymoKiekis.Add(uzsakymoKiekisNew[i]);
                uzsakymoPrioNew[i].transform.position = new Vector3(uzsakymoPrio[uzsakymoPrio.Count - 1].transform.position.x, uzsakymoPrio[uzsakymoPrio.Count - 1].transform.position.y - 1, 0);
                uzsakymoPrio.Add(uzsakymoPrioNew[i]);
                uzsakymoCheckBoxNew[i].transform.position = new Vector3(uzsakymoCheckBox[uzsakymoCheckBox.Count - 1].transform.position.x, uzsakymoCheckBox[uzsakymoCheckBox.Count - 1].transform.position.y - 1, 0);
                uzsakymoCheckBoxNew[i].GetComponent<Toggle>().isOn = false;
                uzsakymoCheckBox.Add(uzsakymoCheckBoxNew[i]);
                uzsakymoPavadinimasNew.RemoveAt(i);
                uzsakymoKiekisNew.RemoveAt(i);
                uzsakymoPrioNew.RemoveAt(i);
                uzsakymoCheckBoxNew.RemoveAt(i);
                check = true;
            }
        }
        if (check)
        {
            errorZinomiMessage.SetActive(false);
            errorNaujiMessage.SetActive(false);
        }
        else
        {
            errorZinomiMessage.SetActive(false);
            errorNaujiMessage.SetActive(true);
            StartCoroutine(TextDisable(errorNaujiMessage));
        }
    }
}
