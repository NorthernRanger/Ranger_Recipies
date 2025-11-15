using MelonLoader;
using HarmonyLib;
using Il2Cpp;

[assembly: MelonInfo(typeof(Ranger_Recipes.Core), "Ranger_Recipes", "0.1.1", "Northern Ranger", "https://github.com/NorthernRanger/Ranger_Recipes/releases/download/0.1.0/Ranger_Recipes.modcomponent")]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace Ranger_Recipes
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Ranger_Recipes ready to rumble!");
        }
    }

    internal static class CattailRhizome
    {
        [HarmonyPatch(typeof(Harvestable), "Harvest")]
        private static class AddRhizomeToCattail
        {
            private static void Postfix(ref Harvestable __instance)
            {
                MelonLogger.Warning("Plant harvested");

                string HarvestedPlantName = __instance.m_GearPrefab.DisplayName;
                GearItem Rhizome = GearItem.LoadGearItemPrefab("GEAR_CattailRhizomeRaw");

                if(HarvestedPlantName == "Cat Tail Stalk")
                {
                    GameManager.GetPlayerManagerComponent().AddItemToPlayerInventory(Rhizome, true, true);
                    MelonLogger.Warning("Added Cattail Rhizome to inventory.");
                }
            }
        }
    }
}