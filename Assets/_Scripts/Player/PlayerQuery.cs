using System;
using System.Collections.Generic;
using UnityEngine;

namespace GJ25.Player
{
    public class PlayerQuery : MonoBehaviour
    {
        public static PlayerQuery instance;

        private void Awake()
        {
            instance = this;
        }

        public List<PlayerBase> players = new();
    }
}

