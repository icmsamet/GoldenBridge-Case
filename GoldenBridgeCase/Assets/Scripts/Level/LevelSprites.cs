using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "New Level Sprites",menuName = "Create New Level Sprites")]
    public class LevelSprites : ScriptableObject
    {
        public Sprite mainSprite;
        public List<Sprite> sprites = new List<Sprite>();
    }
}
