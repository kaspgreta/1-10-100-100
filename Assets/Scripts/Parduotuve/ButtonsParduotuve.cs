using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsParduotuve : MonoBehaviour
{
    public GameObject infoPanel, pranesimoPanel;
    public GameObject errorMessage, errorMessage2;
    public GameObject pranesimoText, sekmingaiText;
    public Text siuntosIdPranesimui;
    public GameObject preke, prekesUzsakymas, content, contentUzsakymas;
    public GameObject toggle;

    List<GameObject> prekesPavadinimas = new List<GameObject>();
    List<GameObject> prekesKiekis = new List<GameObject>();
    List<GameObject> prekesCheckBox = new List<GameObject>();

    List<GameObject> prekesUzsakymasPavadinimas = new List<GameObject>();
    List<GameObject> prekesUzsakymasKiekis = new List<GameObject>();
    List<GameObject> prekesUzsakymasPrio = new List<GameObject>();
    List<GameObject> prekesUzsakymasCheckBox = new List<GameObject>();

    void Start() //Testiniai duomenys
    {
        GameObject s;
        for (int i = 0; i < 10; i++)
        {
            s = Instantiate(preke);
            s.transform.SetParent(content.transform, false);
            s.GetComponent<Transform>().position = new Vector3(s.transform.position.x, -i, 0);
            s.name = "Prekė" + i.ToString();
            s.transform.GetChild(0).GetComponent<Text>().text = "prekės numeris" + i.ToString();

            prekesPavadinimas.Add(s.transform.GetChild(0).gameObject);       
            prekesKiekis.Add(s.transform.GetChild(1).gameObject);      
            prekesCheckBox.Add(s.transform.GetChild(2).gameObject);         
        }

        for (int i = 0; i < 10; i++)
        {
            s = Instantiate(prekesUzsakymas);
            s.transform.SetParent(contentUzsakymas.transform, false);
            s.GetComponent<Transform>().position = new Vector3(s.transform.position.x, -i, 0);
            s.name = "PrekėsUzsakymas" + i.ToString();
            s.transform.GetChild(0).GetComponent<Text>().text = "prekės užsakymo numeris" + i.ToString();

            prekesUzsakymasPavadinimas.Add(s.transform.GetChild(0).gameObject);
            prekesUzsakymasKiekis.Add(s.transform.GetChild(1).gameObject);
            prekesUzsakymasPrio.Add(s.transform.GetChild(2).gameObject);
            prekesUzsakymasCheckBox.Add(s.transform.GetChild(3).gameObject);
        }

    }

    void Update()
    {

    }

    public GameObject p1, p2, p3;
    public void TurimosPrekesOpen() // ar reikia tuomet home mygtuko?
    {
        p2.SetActive(false);
        p3.SetActive(false);
        p1.SetActive(true);
    }

    public void PateiktiUzsakymaiOpen()
    {
        p1.SetActive(false);
        p3.SetActive(false);
        p2.SetActive(true);
    }

    public void NaujasUzsakymasOpen()
    {
        p2.SetActive(false);
        p1.SetActive(false);
        p3.SetActive(true);
    }

    /*  public void PazymetiVisas()
      {
          if (toggle.GetComponent<Toggle>().isOn)
          {
              for (int i = 0; i < siuntosPavadinimas.Count; i++)
              {
                  siuntosCheckBox[i].GetComponent<Toggle>().isOn = true;
                  toggle.transform.GetChild(1).GetComponent<Text>().text = "Atžymėti visas siuntas";
              }
          }
          else
          {
              for (int i = 0; i < siuntosPavadinimas.Count; i++)
              {
                  siuntosCheckBox[i].GetComponent<Toggle>().isOn = false;
                  toggle.transform.GetChild(1).GetComponent<Text>().text = "Pažymėti visas siuntas";
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
          siuntosIdPranesimui.text = "";
          for (int i = 0; i < siuntosPavadinimas.Count; i++)
          {
              if (siuntosCheckBox[i].GetComponent<Toggle>().isOn)
              {
                  siuntosIdPranesimui.text += count.ToString() + ". ";
                  siuntosIdPranesimui.text += siuntosPavadinimas[i].GetComponent<Text>().text;
                  siuntosIdPranesimui.text += " , ";
                  siuntosIdPranesimui.text += siuntosAdresas[i].GetComponent<Text>().text;
                  siuntosIdPranesimui.text += " ";
                  count++;
                  check = true;
              }
          }
          if (check)
          {
              errorMessage2.SetActive(false);
              pranesimoPanel.SetActive(true);
          }
          else
          {
              errorMessage2.SetActive(true);
              StartCoroutine(TextDisable(errorMessage2));
          }
      }

      public void AtnaujintiSiuntas() //Atnaujinti vairuotojo siuntas!!!
      {
          sekmingaiText.SetActive(true);
          StartCoroutine(TextDisable(sekmingaiText));

      }

      private IEnumerator TextDisable(GameObject text)
      {
          yield return new WaitForSeconds(3);
          text.SetActive(false);
      }

      public void PagrindinisLangas()
      {
          pranesimoPanel.SetActive(false);
      }

      public void PatvirtintiPristatyma() //Perduoti informaciją
      {
          bool check = false;
          for (int i = siuntosPavadinimas.Count - 1; i >= 0; i--)
          {
              if (siuntosCheckBox[i].GetComponent<Toggle>().isOn)
              {
                  for (int j = siuntosPavadinimas.Count - 1; j > i; j--)
                  {
                      siuntosPavadinimas[j].transform.position = new Vector3(siuntosPavadinimas[j - 1].transform.position.x, siuntosPavadinimas[j - 1].transform.position.y, 0);
                      siuntosAdresas[j].transform.position = new Vector3(siuntosAdresas[j - 1].transform.position.x, siuntosAdresas[j - 1].transform.position.y, 0);
                      siuntosCheckBox[j].transform.position = new Vector3(siuntosCheckBox[j - 1].transform.position.x, siuntosCheckBox[j - 1].transform.position.y, 0);
                  }
                  Destroy(siuntosAdresas[i].transform.parent.gameObject);
                  siuntosPavadinimas.RemoveAt(i);
                  siuntosAdresas.RemoveAt(i);
                  siuntosCheckBox.RemoveAt(i);
                  check = true;
              }
          }
          if (check)
          {
              errorMessage2.SetActive(false);
          }
          else
          {
              errorMessage2.SetActive(true);
              StartCoroutine(TextDisable(errorMessage2));
          }
      }*/
}
