using UnityEngine;

namespace GJ25.Player
{
    public class PlayerControls : MonoBehaviour
    {
        public KeyCode up;
        public KeyCode left;
        public KeyCode right;
        public KeyCode down;
        public KeyCode interact;

        public void FlipControls(bool flip)
        {
            if (flip)
            {
                (up, down) = (down, up);
                (left, right) = (right, left);
            }
            else
            {
                (down, up) = (up, down);
                (right, left) = (left, right);
            }
        }
    }
}