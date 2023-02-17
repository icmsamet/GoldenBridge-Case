using TMPro;
using UnityEngine;

namespace Cell
{
    public class NumberPositioner
    {
        PolygonCollider2D m_Collider;
        TextMeshPro m_Text;

        public NumberPositioner(PolygonCollider2D _polygonCollider, TextMeshPro _textMesh)
        {
            m_Collider = _polygonCollider;
            m_Text = _textMesh;
        }

        public void SetTextPosition()
        {
            m_Text.sortingOrder = 2;
            m_Text.transform.position = CenterOfBounds();
            m_Text.text = "0";
        }

        public Vector2 CenterOfBounds()
        {
            return m_Collider.bounds.center;
        }
    }
}
