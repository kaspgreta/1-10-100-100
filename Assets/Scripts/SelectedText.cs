using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
 public class SelectedText : MonoBehaviour {

    public Text[] text;

    public void OnClick(Text text)
    {
        text.color = new Color(0, 0, 0);
        for (int i = 0; i < this.text.Length; i++)
        {
            if (this.text[i].tag != text.tag)
            {
                this.text[i].color = new Color(255, 255, 255);
            }
        }

    }
}