using UnityEngine;
namespace agora_utilities
{
    public class AgoraUIUtils
    {
        public static Vector2 GetScaledDimension(float width, float height, float WindowSideLength)
        {
            float newWidth = width;
            float newHeight = height;
            float ratio = (float)height / (float)width;
            if (width > height)
            {
                newHeight = WindowSideLength;
                newWidth = WindowSideLength / ratio;
            }
            else
            {
                newHeight = WindowSideLength * ratio;
                newWidth = WindowSideLength;
            }
            return new Vector2(newWidth, newHeight);
        }
    }
}
