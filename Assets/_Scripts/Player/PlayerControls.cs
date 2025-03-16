using UnityEngine;

namespace GJ25.Player
{
    public class PlayerControls : MonoBehaviour
    {
        private KeyCode _originalUp;
        private KeyCode _originalDown;
        private KeyCode _originalLeft;
        private KeyCode _originalRight;
        public KeyCode up;
        public KeyCode left;
        public KeyCode right;
        public KeyCode down;
        public KeyCode interact;

        private void Start()
        {
            _originalUp = up;
            _originalDown = down;
            _originalLeft = left;
            _originalRight = right;
        }

        public void FlipControls(bool flip)
        {
            if (flip)
            {
                up = _originalDown;
                down = _originalUp;
                left = _originalRight;
                right = _originalLeft;
            }
            else
            {
                up = _originalUp;
                down = _originalDown;
                left = _originalLeft;
                right = _originalRight;
            }
        }
    }
}