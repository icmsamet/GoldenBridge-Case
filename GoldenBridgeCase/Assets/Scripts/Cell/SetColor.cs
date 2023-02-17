using DG.Tweening;
using UnityEngine;

namespace Cell
{
    public class SetColor
    {
        SpriteRenderer spriteRenderer;

        public SetColor(SpriteRenderer _spriteRenderer)
        {
            spriteRenderer = _spriteRenderer;
        }

        public void Colorize()
        {
            spriteRenderer.DOFade(1, 1).SetEase(Ease.InOutCubic);
        }

        public void Highlight()
        {
            spriteRenderer.DOFade(.4f, 1).SetEase(Ease.InOutCubic);
        }

        public void UnHighlight()
        {
            spriteRenderer.DOFade(0, 1).SetEase(Ease.InOutCubic);
        }
    }
}
