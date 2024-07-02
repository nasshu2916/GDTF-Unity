using GDTF.Data.PhysicalDescriptions;
using GDTF.Editor.Utility;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace GDTF.Editor.PropertyDrawer
{
    [CustomPropertyDrawer(typeof(Properties))]
    public class PropertiesDrawer : UnityEditor.PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement
            {
                style =
                {
                    marginTop = 10,
                    marginBottom = 10
                }
            };

            var label = new Label("Properties")
            {
                style =
                {
                    unityFontStyleAndWeight = FontStyle.Bold,
                    paddingBottom = 5
                }
            };
            container.Add(label);

            var element = new PropertyField(property.FindPropertyRelative("operatingTemperature"));
            element.Bind(property.serializedObject);
            container.Add(element);

            element = new PropertyField(property.FindPropertyRelative("weight"));
            element.Bind(property.serializedObject);
            container.Add(element);

            element = new PropertyField(property.FindPropertyRelative("legHeight"));
            element.Bind(property.serializedObject);
            container.Add(element);

            return container;
        }
    }

    [CustomPropertyDrawer(typeof(OperatingTemperature))]
    public class OperatingTemperatureDrawer : UnityEditor.PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            container.Add(ElementUtility.PropertyFieldWithUnits(property.FindPropertyRelative("low"),
                "Operating Temperature Low",
                "℃"));
            container.Add(ElementUtility.PropertyFieldWithUnits(property.FindPropertyRelative("high"),
                "Operating Temperature High",
                "℃"));

            return container;
        }
    }

    [CustomPropertyDrawer(typeof(Weight))]
    public class WeightDrawer : UnityEditor.PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            container.Add(
                ElementUtility.PropertyFieldWithUnits(property.FindPropertyRelative("value"),
                    "Weight",
                    "kg"));

            return container;
        }
    }

    [CustomPropertyDrawer(typeof(LegHeight))]
    public class LegHeightDrawer : UnityEditor.PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            container.Add(
                ElementUtility.PropertyFieldWithUnits(property.FindPropertyRelative("value"),
                    "Leg Height",
                    "mm"));

            return container;
        }
    }
}
