using System.IO;
using System.Xml;
using GDTF.Data;
using GDTF.Utils;
using UnityEditor;
using UnityEngine;

namespace GDTF.Editor
{
    public class GdtfLoader : UnityEditor.Editor
    {
        private static readonly string LoadDir = Application.dataPath;
        private const string GdtfRegex = "*.gdtf";

        [MenuItem("GDTF/UnZip and Deserialize All")]
        public static void UnzipAndDeserializeAll()
        {
            if (!Directory.Exists(LoadDir))
            {
                Debug.LogError("GDTF Load Directory Not Found!: " + LoadDir);
                return;
            }

            var direction = new DirectoryInfo(LoadDir);
            var gdtfFiles = direction.GetFiles(GdtfRegex, SearchOption.AllDirectories);
            Debug.Log($"Find {gdtfFiles.Length} GDTF Files");

            foreach (var gdtfFile in gdtfFiles)
            {
                UnzipAndDeserialize(gdtfFile);
            }

            AssetDatabase.Refresh();
        }

        private static void UnzipAndDeserialize(FileInfo file)
        {
            var gdtfPath = file.ToString();
            var directory = Path.GetDirectoryName(gdtfPath);
            var fileName = Path.GetFileNameWithoutExtension(gdtfPath);

            var unZipPath = $"{directory}/{fileName}/";
            var result = Unzip(gdtfPath, unZipPath);
            if (!result)
            {
                Debug.LogError("UnZip GDTF File Error: " + fileName);
                return;
            }

            var descriptionPath = unZipPath + "Description.xml";
            var data = DeserializeGdtf(descriptionPath);
            if (data == null)
            {
                Debug.LogError("Deserialize GDTF File Error: " + fileName);
                return;
            }
            data.fileName = fileName;

            var assetPath = $"Assets/GDTF/Resources/{fileName}.asset";
            var assetDir = Path.GetDirectoryName(assetPath);

            if (!Directory.Exists(assetDir))
            {
                Directory.CreateDirectory(assetDir!);
            }

            AssetDatabase.CreateAsset(data, assetPath);
            AssetDatabase.SaveAssets();
        }

        private static bool Unzip(string gdtfPath, string unZipPath)
        {
            if (!Directory.Exists(unZipPath))
            {
                Directory.CreateDirectory(unZipPath);
            }

            return ZipUtils.Unzip(gdtfPath, unZipPath);
        }

        private static GdtfData DeserializeGdtf(string descriptionPath)
        {
            if (!File.Exists(descriptionPath))
            {
                Debug.LogError("Description.xml Not Found: " + descriptionPath);
                return null;
            }

            var xml = new XmlDocument();
            xml.Load(descriptionPath);

            var root = xml.DocumentElement;
            if (root == null)
            {
                Debug.LogError("XML Root is null");
                return null;
            }

            var data = CreateInstance<GdtfData>();
            data.LoadXml(root);

            return data;
        }
    }
}
