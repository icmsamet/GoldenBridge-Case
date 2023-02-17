using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace ColorPicker
{
    public class ColorPicker : MonoBehaviour
    {
        Button myButton;
        TextMeshProUGUI myText;
        [HideInInspector] public Color myColor;
        Image myRenderer;
        public int myNumber;


        private void Start()
        {
            myText = GetComponentInChildren<TextMeshProUGUI>();
            myText.text = myNumber.ToString();
            myButton = GetComponent<Button>();
            myButton.onClick.AddListener(SendNumber);
            myRenderer = GetComponent<Image>();
            myRenderer.color = myColor;
            myRenderer.DOFade(1, 0);
        }

        public void SendNumber()
        {
            PickerManager.instance.SetNumber(myNumber);
        }
    }
}
