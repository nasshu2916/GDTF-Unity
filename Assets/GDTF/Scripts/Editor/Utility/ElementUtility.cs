using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GDTF.Editor.Utility
{
    public static class ElementUtility
    {
        public static VisualElement PropertyFieldWithUnits(SerializedProperty property, string label, string unit = "")
        {
            var container = new VisualElement
            {
                style = { flexDirection = FlexDirection.Row }
            };

            var field = new PropertyField(property)
            {
                label = label,
                style = { flexGrow = 1 }
            };
            field.Bind(property.serializedObject);

            var labelElement = new Label(unit)
            {
                style =
                {
                    alignSelf = Align.Center,
                    paddingLeft = 10,
                    paddingRight = 10,
                    minWidth = 45
                }
            };

            container.Add(field);
            container.Add(labelElement);
            return container;
        }
    }
}
