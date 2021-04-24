using System;
using System.Reflection;
using Terraria.ModLoader;

namespace ModularEffectLib
{
    internal static class LoadingHelper
    {
        internal static object LoadMods;

        // string stageText, int modCount = -1
        internal static MethodInfo SetLoadStageMethod;
        // string text
        internal static PropertyInfo SubProgressTextProperty;
        // float amount
        internal static PropertyInfo ProgressProperty;

        internal static void Load()
        {
            Assembly modLoader = typeof(ModLoader).Assembly;
            LoadMods = modLoader.GetType("Terraria.ModLoader.UI.Interface").GetField("loadMods", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);

            Type uiLoadMods = modLoader.GetType("Terraria.ModLoader.UI.UILoadMods");

            SetLoadStageMethod = uiLoadMods.GetMethod("SetLoadStage", BindingFlags.Public | BindingFlags.Instance);
            SubProgressTextProperty = uiLoadMods.GetProperty("SubProgressText", BindingFlags.Public | BindingFlags.Instance);
            ProgressProperty = uiLoadMods.GetProperty("Progress", BindingFlags.Public | BindingFlags.Instance);
        }

        internal static void SetLoadStage(string text)
        {
            SetLoadStageMethod.Invoke(LoadMods, new object[] { text, -1 });
        }

        internal static void SubProgress(string text)
        {
            SubProgressTextProperty.SetValue(LoadMods, text);
        }

        internal static void Progress(float progress)
        {
            ProgressProperty.SetValue(LoadMods, progress);
        }

        internal static void Unload()
        {
            LoadMods = null;

            SetLoadStageMethod = null;
            SubProgressTextProperty = null;
            ProgressProperty = null;
        }
    }
}
