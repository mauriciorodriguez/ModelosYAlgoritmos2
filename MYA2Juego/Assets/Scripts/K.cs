﻿using UnityEngine;
using System.Collections;

public class K
{
    // ===== INPUT =====
    public const string INPUT_HORIZONTAL = "Horizontal";
    public const string INPUT_VERTICAL = "Vertical";

    // ===== LAYERS =====
    public const int LAYER_PLAYER= 8;
    public const int LAYER_ASTEROID = 9;

    // ===== TAGS =====
    public const string TAG_PLAYER = "Player";
    public const string TAG_MANAGERS = "Managers";
    public const string TAG_ENEMIES = "Enemies";
    public const string TAG_BULLETS = "Bullets";
    public const string TAG_POWERUPS = "Powerups";

    // ===== SHOOT TYPE =====
    public const string SHOOT_TYPE_AUTOMATIC = "Automatic";
    public const string SHOOT_TYPE_LASER = "Laser";
    public const string SHOOT_TYPE_BOMB = "Bomb";

    // ===== SHOOT RATE =====
    public const float SHOOT_RATE_AUTOMATIC = 0.25f;

    // ===== BULLET LIFE TIME =====
    public const float BULLET_LIFETIME = 2f;
}
