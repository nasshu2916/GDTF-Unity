using System;

namespace GDTF
{
    [Serializable]
    public class ColorCIE
    {
        public float x;
        public float y;
        public float z;

        public ColorCIE(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public ColorCIE(string text)
        {
            var values = text.Split(',');
            x = float.Parse(values[0]);
            y = float.Parse(values[1]);
            z = float.Parse(values[2]);
        }
    }
}
