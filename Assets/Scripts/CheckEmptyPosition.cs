using UnityEngine;

namespace DefaultNamespace
{
    public class CheckEmptyPosition
    {
        public static float GetEmptyRow(GameContext context, Vector2 position)
        {
            position.y -= 1.5f;

            while (position.y >= 0 && context.GetEntitiesWithPosition(position).Count == 0)
            {
                position.y -= 1.5f;
            }

            return position.y + 1.5f;
        }
    }
}