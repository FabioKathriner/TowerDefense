﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TextUpdater : MonoBehaviour
    {
        private Text _textObject;

        private void Start()
        {
            _textObject = GetComponent<Text>();
        }

        public void UpdateText(string text)
        {
            _textObject.text = text;
        }
    }
}