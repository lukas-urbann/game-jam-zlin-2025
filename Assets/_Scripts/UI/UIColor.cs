using UnityEngine;
using UnityEngine.UI;

namespace GJ25.UI
{
    public class UIColor : MonoBehaviour
    {
        [SerializeField] private Graphic _graphic;
        [SerializeField] private Color[] _colors;

        public void UpdateColor(int index) => _graphic.color = _colors[index];
    }
}
