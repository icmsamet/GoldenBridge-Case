using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorPicker;
namespace Cell
{
    public class CheckColor
    {
        Cell m_Cell;
        public CheckColor(Cell _cell)
        {
            m_Cell = _cell;
        }

        public bool Check()
        {
            if(PickerManager.instance.SelectedNumber == m_Cell.typeNumber)
            {
                return true;
            }
            return false;
        }
    }
}
