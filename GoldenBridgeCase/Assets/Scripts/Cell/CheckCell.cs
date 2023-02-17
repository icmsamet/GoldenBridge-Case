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
            // Fare týklamasý algýlama
            if (Input.GetMouseButtonDown(0))
            {
                // Fare pozisyonunu al
                Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                // Raycast yap
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                // Eðer bir þey isabet ettiyse
                if (hit.collider != null)
                {
                    Cell cell = hit.collider.gameObject.GetComponent<Cell>();
                    cell.Check();
                }
            }
        }
    }
}
