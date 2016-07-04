using UnityEngine;
using System.Collections;

public class K
{
    // ===== INPUT =====
    public const string INPUT_HORIZONTAL = "Horizontal";
    public const string INPUT_VERTICAL = "Vertical";

    // ===== LAYERS =====
    public const int LAYER_PLAYER= 8;
    public const int LAYER_ASTEROID = 9;
    public const int LAYER_BLACKHOLE = 10;
    public const int LAYER_BULLET = 11;
    public const int LAYER_SMALL_ASTEROID = 12;
    public const int LAYER_MEDIUM_ASTEROID = 13;
    public const int LAYER_BIG_ASTEROID = 14;
    public const int LAYER_BOMB = 15;
    public const int LAYER_SECOND_SHIP = 16;
    public const int LAYER_POWERUP = 17;

    // ===== TAGS =====
    public const string TAG_PLAYER = "Player";
    public const string TAG_MANAGERS = "Managers";
    public const string TAG_ENEMIES = "Enemies";
    public const string TAG_AMMO = "Ammo";
    public const string TAG_POWERUPS = "Powerups";
    public const string TAG_LIFES = "Lifes";
    public const string TAG_MODEL = "Model";

    // ===== SHOOT TYPE =====
    public const string SHOOT_TYPE_AUTOMATIC = "Automatic";
    public const string SHOOT_TYPE_LASER = "Laser";
    public const string SHOOT_TYPE_BOMB = "Bomb";

    // ===== BULLETS CONFIG =====
    public const float SHOOT_RATE_AUTOMATIC = 0.25f;
    public const float SHOOT_RATE_BOMB = 0.5f;
    public const float BULLET_LIFETIME = 2f;
    public const float LASER_MAX_DISTANCE = 5;

    // ===== SHOOT TYPE =====
    public const int PLAYER_LIFES = 3;

    // ===== FACADE MSG =====
    public const string FACADE_MSG_WIN = "Win";
    public const string FACADE_MSG_LOSE = "Lose";
    public const string FACADE_MSG_TIE = "Tie";
    public const string FACADE_MSG_CONTROL = "";

    // ===== OBSERVER MESSAGES =====
    public const string OBSERVER_PLAYER_ADD_LIVES = "AddLives";
    public const string OBSERVER_PLAYER_SCORE = "Score";
    public const string OBSERVER_PLAYER_LIVES = "Lives";

    // ===== ASTEROIDS COUNT =====
    public const int ASTEROIDS_COUNT_LEVEL1 = 20;
    public const float ASTEROIDS_SPAWN_TIMER = 5f;

    // ===== POWERUP NAMES =====
    public const string POWERUP_AUTOMATIC = SHOOT_TYPE_AUTOMATIC;
    public const string POWERUP_LASER = SHOOT_TYPE_LASER;
    public const string POWERUP_BOMB = SHOOT_TYPE_BOMB;
}
