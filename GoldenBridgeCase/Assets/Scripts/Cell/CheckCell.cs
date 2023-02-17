using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cell
{
    public class CheckCell : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        void Update()
        {
            // Fare t�klamas� alg�lama
            if (Input.GetMouseButtonDown(0))
            {
                // Fare pozisyonunu al
                Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                // Raycast yap
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                // E�er bir �ey isabet ettiyse
                if (hit.collider != null)
                {
                    Cell cell = hit.collider.gameObject.GetComponent<Cell>();
                    cell.Check();
                }
            }
        }
    }
}
