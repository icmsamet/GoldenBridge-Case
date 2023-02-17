using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEditor;

namespace Level
{
    public class LevelGenerator : MonoBehaviour
    {
        #region Check Bools
        bool hasnotLevelSprites = true;
        bool hasGeneratedLevel = false;
        #endregion
        #region Private Variables
        GameObject m_MainSprite;
        #endregion

        [InfoBox("Please Check All Cells Text", VisibleIf = "hasGeneratedLevel", InfoMessageType = InfoMessageType.Info)]

        [InfoBox("Please get 'Level Sprites' from Resources folder.", VisibleIf = "hasnotLevelSprites", InfoMessageType = InfoMessageType.Warning)]
        [SerializeField]
        [OnValueChanged("CheckPropertiesLevelSprites")] LevelSprites levelSprites;
        void CheckPropertiesLevelSprites()
        {
            hasnotLevelSprites = !levelSprites;
            if (!levelSprites)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }

        [HideIf("hasnotLevelSprites")]
        [Button("Generate Level")]
        void GenerateLevel()
        {
            if(m_MainSprite != null) { return; }
            hasGeneratedLevel = true;
            m_MainSprite = new GameObject("MainSprite");
            m_MainSprite.transform.SetParent(this.transform);
            m_MainSprite.AddComponent<SpriteRenderer>().sprite = levelSprites.mainSprite;
            m_MainSprite.transform.localScale = new Vector3(.12f, .12f);
            Level newLevel = m_MainSprite.AddComponent<Level>();

            int index = 0;
            while (index < levelSprites.sprites.Count)
            {
                GameObject newCell = new GameObject("Cell"+index);
                newCell.transform.SetParent(m_MainSprite.transform);
                newCell.transform.localScale = Vector3.one;
                SpriteRenderer spriteRenderer = newCell.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = levelSprites.sprites[index];
                spriteRenderer.sortingOrder = 1;
                newCell.AddComponent<PolygonCollider2D>();
                Cell.Cell cell = newCell.AddComponent<Cell.Cell>();
                GameObject cellTextMesh = new GameObject("TextMesh");
                cellTextMesh.transform.SetParent(newCell.transform);
                TextMeshPro textMeshPro = cellTextMesh.AddComponent<TextMeshPro>();
                textMeshPro.fontSize = 2;
                textMeshPro.alignment = TextAlignmentOptions.Center;
                textMeshPro.color = Color.black;
                cell.GetComponent<Cell.Cell>().SetNumberTextPosition();
                index++;
            }
        }

        [HideIf("hasnotLevelSprites")]
        [Button("Remove Level")]
        void RemoveLevel()
        {
            if (m_MainSprite == null) { return; }
            DestroyImmediate(m_MainSprite);
            hasGeneratedLevel = false;
        }

        [Button("Save Prefab")]
        [ShowIf("hasGeneratedLevel")]
        void SaveLevelPrefab()
        {
            string levelPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Prefabs/" + levelSprites.name + ".prefab");
            GameObject levelPrefab = PrefabUtility.SaveAsPrefabAsset(m_MainSprite, levelPath);
        }



        private void OnDrawGizmosSelected()
        {
            CheckPropertiesLevelSprites();
        }
    }
}
