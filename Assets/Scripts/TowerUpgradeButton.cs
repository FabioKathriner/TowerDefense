﻿using Assets.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TowerUpgradeButton : TowerButton
    {
        protected override string GetNewPrice(Tower selectedTower)
        {
            return selectedTower.UpgradePrice.ToString();
        }
    }
}
