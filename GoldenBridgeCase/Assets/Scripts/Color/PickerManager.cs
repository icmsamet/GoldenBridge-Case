using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ColorPicker
{
    public class PickerManager : MonoBehaviour
    {
        private static PickerManager _ins;
        public static PickerManager instance
        {
            get
            {
                if (_ins == null)
                    _ins = FindObjectOfType<PickerManager>();

                return _ins;
            }
        }
        public int SelectedNumber;
        [SerializeField] Transform prefabParent;
        [SerializeField] Level.Level level;
        GameObject m_ColorPickerPrefab;
        [SerializeField] List<GameObject> colorPickers = new List<GameObject>();

        private void Start()
        {
            level = FindObjectOfType<Level.Level>();
            m_ColorPickerPrefab = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Resources/ColorPickerPrefab.prefab", typeof(GameObject));

            for (int i = 0; i < level.colorLists.Count; i++)
            {
                GameObject colorPicker = Instantiate(m_ColorPickerPrefab, Vector3.zero, Quaternion.identity, prefabParent);
                colorPicker.GetComponent<ColorPicker>().myNumber = level.colorLists[i].number;
                colorPicker.GetComponent<ColorPicker>().myColor = level.colorLists[i].color;
                colorPickers.Add(colorPicker);
            }
        }

        public void SetNumber(int newNumber)
        {
            SelectedNumber = newNumber;
            CheckAllCells();
        }
        public void CheckAllCells()
        {
            foreach (var item in level.transform.GetComponentsInChildren<Cell.Cell>())
            {
                if (!item.isFilled)
                {
                    item.UnHighlight();
                    if (item.typeNumber == SelectedNumber)
                    {
                        item.Highlight();
                    }
                }
                else
                {
                    for (int i = 0; i < level.colorLists.Count; i++)
                    {
                        if (level.cellsLists[i].cells.Where(x => x.isFilled).Count() == level.cellsLists[i].cells.Count)
                        {
                            Destroy(colorPickers[i]);
                            colorPickers.RemoveAt(i);
                            level.cellsLists.RemoveAt(i);
                            level.colorLists.RemoveAt(i);
                        }
                    }
                }
            }
        }
    }
}
