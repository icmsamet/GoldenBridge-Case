using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cell
{
    public class Cell : MonoBehaviour
    {
        public int typeNumber;
        public bool isFilled = false;
        SpriteRenderer spriteRenderer;
        TextMeshPro m_Text;
        PolygonCollider2D m_Collider;
        CheckColor checkColor;
        SetColor setColor;
        Number m_Number;
        NumberPositioner m_NumberPositioner;

        private void Start()
        {
            m_Text = GetComponentInChildren<TextMeshPro>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1, 1, 1, 0);
            checkColor = new CheckColor(this);
            setColor = new SetColor(spriteRenderer);
        }
        public void SetNumberTextPosition()
        {
            m_Text = GetComponentInChildren<TextMeshPro>();
            m_Collider = GetComponent<PolygonCollider2D>();
            m_NumberPositioner = new NumberPositioner(m_Collider, m_Text);
            m_NumberPositioner.SetTextPosition();
        }
        public void SetNumber()
        {
            m_Text = GetComponentInChildren<TextMeshPro>();
            m_Number = new Number(m_Text);
            m_Number.SetNumber(typeNumber);
        }
        public void Check()
        {
            if (checkColor.Check())
            {
                setColor.Colorize();
                //ColorPicker.PickerManager.instance.CheckAllCells();
                isFilled = true;
                if(m_Text != null)
                    Destroy(m_Text.gameObject);
            }
        }
        public void Highlight()
        {
            setColor.Highlight();
        }

        public void UnHighlight()
        {
            setColor.UnHighlight();
        }
    }
}
