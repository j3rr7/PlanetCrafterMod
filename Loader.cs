using UnityEngine;
using HarmonyLib;

using Object = UnityEngine.Object;
using SpaceCraft;
using System.IO;
using System.Reflection;
using System;

namespace PlanetCrafterMod
{
    public static class Loader
    {
        private static GameObject _gameObject;
        private static bool _harmonyPatched;

        public static GameObject GameObjectRef => _gameObject;

        public static void Load()
        {
            _Load();
        }

        public static void _Load(bool shouldLoadHarmony = false)
        {
            if (_gameObject != null) return;

            _gameObject = new GameObject("PlanetCrafterMod");
            _gameObject.AddComponent<ModEntry>();
            Object.DontDestroyOnLoad(_gameObject);

            if (shouldLoadHarmony)
            {
                LoadHarmonyPatch();
            }
        }

        public static void Unload()
        {
            if (_gameObject == null) return;

            Object.Destroy(_gameObject);
            _gameObject = null;
            _harmonyPatched = false;
        }

        private static void LoadHarmonyPatch()
        {
            if (_harmonyPatched) return;

            string name = "PlanetCrafterMod.Resources.0Harmony.dll";
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null) return; // Handle case where the resource is not found

                byte[] rawAssembly = new byte[stream.Length];
                stream.Read(rawAssembly, 0, (int)stream.Length);
                AppDomain.CurrentDomain.Load(rawAssembly);
                _harmonyPatched = true;
            }
        }
    }
}