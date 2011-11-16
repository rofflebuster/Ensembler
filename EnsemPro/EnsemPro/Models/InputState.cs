﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public struct InputState
{
    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Acceleration;
    public bool Pause;
    public bool Confirm;
    public Keys Key;
    public bool Up;
    public bool Down;
}