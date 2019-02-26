using System.Drawing;

/// <summary>
/// колизия
/// </summary>
interface ICollision
{
    bool Collision(ICollision obj);
    Rectangle Rect { get; }
}