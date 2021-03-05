using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace FindSpace
{
    [BepInPlugin("com.celeo.valheim.findspace", "Find Space", "1.0.0.0")]
    public class FindSpacePlugin : BaseUnityPlugin
    {
        private static Harmony harmonyInstance;

        void Awake()
        {
            UnityEngine.Debug.Log("FindSpace plugin initialized"); harmonyInstance = Harmony.CreateAndPatchAll(
                 Assembly.GetExecutingAssembly(),
                 "com.celeo.valheim.findspace"
                );
        }

        void OnDestroy()
        {
            harmonyInstance.UnpatchSelf();
        }
    }
}
