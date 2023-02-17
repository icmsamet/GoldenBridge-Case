using TMPro;
using UnityEngine;

namespace Cell
{
    public class Number
    {
        TextMeshPro meshPro;

        public Number(TextMeshPro _textMeshPro)
        {
            meshPro = _textMeshPro;
        }

        public void SetNumber(int number)
        {
            meshPro.text = number.ToString();
        }
    }
}

