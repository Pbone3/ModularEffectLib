using System;
using System.Reflection;
using Terraria.ModLoader;

namespace ModularEffectLib
{
    internal static class LoadingHelper
    {
        internal static object UILoadModsInstance;
        internal static Type UILoadMods;

        internal static FieldInfo StageTextFIeld;
        internal static MethodInfo SetLoadStageMethod;
        internal static PropertyInfo SubProgressTextProperty;
        internal static PropertyInfo ProgressProperty;

        internal static void Load()
        {
            Assembly modLoader = typeof(ModLoader).Assembly;

            UILoadModsInstance = modLoader.GetType("Terraria.ModLoader.UI.Interface").GetField("loadMods", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            UILoadMods = modLoader.GetType("Terraria.ModLoader.UI.UILoadMods");

            StageTextFIeld = UILoadMods.GetField("stageText", BindingFlags.NonPublic | BindingFlags.Instance);
            SetLoadStageMethod = UILoadMods.GetMethod("SetLoadStage", BindingFlags.Public | BindingFlags.Instance);
            SubProgressTextProperty = UILoadMods.GetProperty("SubProgressText", BindingFlags.Public | BindingFlags.Instance);
            ProgressProperty = UILoadMods.GetProperty("Progress", BindingFlags.Public | BindingFlags.Instance);
        }

        internal static void SetLoadStage(string text)
        {
            SetLoadStageMethod.Invoke(UILoadModsInstance, new object[] { text, -1 });
        }

        internal static void SetSubText(string text)
        {
            SubProgressTextProperty.SetValue(UILoadModsInstance, text);
        }

        internal static void SetProgress(float progress)
        {
            ProgressProperty.SetValue(UILoadModsInstance, progress);
        }

        internal static string GetLoadStage()
        {
            return (string)StageTextFIeld.GetValue(UILoadModsInstance);
        }

        internal static void Unload()
        {
            UILoadModsInstance = null;
            UILoadMods = null;

            StageTextFIeld = null;
            SetLoadStageMethod = null;
            SubProgressTextProperty = null;
            ProgressProperty = null;
        }
    }
}
