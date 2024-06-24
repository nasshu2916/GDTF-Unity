using System;
using System.Collections.Generic;
using System.Xml;
using GDTF.Data;
using UnityEditor;
using UnityEngine;

namespace GDTF
{
    public static class GdtfSerializer
    {
        public static T GetAttributeValue<T>(XmlNode node, string attributeName, T defaultValue = default)
        {
            if (node.Attributes == null) return default;
            var attribute = node.Attributes[attributeName];
            return attribute == null ? defaultValue : ParseValue<T>(attribute.Value);
        }
        private static T ParseValue<T>(string value)
        {
            return typeof(T) switch
            {
                var t when t == typeof(string) => (T) (object) value,
                var t when t == typeof(int) => (T) (object) int.Parse(value),
                var t when t == typeof(uint) => (T) (object) uint.Parse(value),
                var t when t == typeof(float) => (T) (object) float.Parse(value),
                var t when t == typeof(DateTime) => (T) (object) DateTime.Parse(value),
                var t when t == typeof(bool) => (T) ParseBool(value),
                var t when t == typeof(GUID) => (T) (object) new GUID(value),
                var t when t == typeof(Color) => (T) ParseColor(value),
                var t when t.IsEnum => (T) Enum.Parse(typeof(T), value),
                _ => throw new InvalidOperationException(typeof(T).ToString())
            };
        }

        private static object ParseBool(string value)
        {
            return value switch
            {
                "Yes" => true,
                "No" => false,
                _ => throw new InvalidOperationException()
            };
        }

        private static object ParseColor(string value)
        {
            var color = new Color();
            var colorValues = value.Split(',');
            color.r = float.Parse(colorValues[0]);
            color.g = float.Parse(colorValues[1]);
            color.b = float.Parse(colorValues[2]);
            return color;
        }

        public static T GetChildNode<T>(XmlNode node, string path) where T : IGdtfElement, new()
        {
            var childNode = node.SelectSingleNode(path);
            if (childNode == null) return default;

            var child = new T();
            child.LoadXml(childNode);
            return child;
        }

        public static List<T> GetChildNodes<T>(XmlNode node, string path) where T : IGdtfElement, new()
        {
            var childNodes = node.SelectNodes(path);
            var children = new List<T>();
            if (childNodes == null) return children;

            foreach (XmlNode childNode in childNodes)
            {
                var child = new T();
                child.LoadXml(childNode);
                children.Add(child);
            }

            return children;
        }
    }
}
