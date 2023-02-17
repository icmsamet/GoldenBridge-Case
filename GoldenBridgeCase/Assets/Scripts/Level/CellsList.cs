using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Level
{
    [System.Serializable]
    public class CellsList
    {
        [OnValueChanged("SetCellNumber")] public List<Cell.Cell> cells = new List<Cell.Cell>();
        [OnValueChanged("SetCellNumber")] public int listNumber = 0;


        void SetCellNumber()
        {
            listNumber = Mathf.Clamp(listNumber, 0, int.MaxValue);
            int index = 0;
            while (index < cells.Count)
            {
                cells[index].typeNumber = listNumber;
                cells[index].SetNumber();
                index++;
            }
        }
    }
}

