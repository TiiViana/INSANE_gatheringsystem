using UnityEngine;
using UnityEngine.UI;


namespace MinimalIconPack
{
    public class ButtonMapper : MonoBehaviour
    {
        public enum AnimationMapper
        {
            MoveUp,
            Pop,
            None
        }
        public enum BackgroundShapeMapper
        {
            Circular,
            Squared,
            SquaredSmooth,
        }


        [Header("Don't edit - hierarchy")]
        public Image icon;
        public Image shadow;
        public Image outline;
        public Image background;
        public Image iconOverlay;
        public RectTransform backgroundParent;


        [Header("Don't edit - references")]
        [Space(25)]
        public Sprite backgroundCircular;
        public Sprite backgroundSquared;
        public Sprite backgroundSquaredSmooth;
    }
}