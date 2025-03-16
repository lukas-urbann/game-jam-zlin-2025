using UnityEngine;
using UnityEngine.UI;

namespace GJ25.UI
{
    public class UIImage : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite[] _images;

        public void UpdateImage(int index) => _image.sprite = _images[index];
    }
}
