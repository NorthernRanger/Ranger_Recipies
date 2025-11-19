using MelonLoader;
using HarmonyLib;
using Il2Cpp;

[assembly: MelonInfo(typeof(Ranger_Recipes.Patches), "Ranger_Recipes", "0.1.2", "Northern Ranger", "https://github.com/NorthernRanger/Ranger_Recipes/releases/download/0.1.0/Ranger_Recipes.modcomponent")]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace Ranger_Recipes
{
    public class Patches : MelonMod
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
                string HarvestedPlantName = __instance.m_GearPrefab.DisplayName; //Gets the display name of the item harvested
                GearItem Rhizome = GearItem.InstantiateGearItem("GEAR_CattailRhizomeRaw");

                if(HarvestedPlantName == "Cat Tail Stalk")
                {
                    GameManager.GetInventoryComponent().AddGear(Rhizome, true); //Adds the rhizome item to the players inventory
                }
            }
        }
    }

    internal static class Stews
    {
        [HarmonyPatch(typeof(CookingPotItem), "StartInspectMode")] //When inspecting an item that is cooking
        private static class DiscardStews
        {
            private static void Prefix(ref CookingPotItem __instance)
            {
                if(__instance.m_GearItemBeingCooked.DisplayName.Contains("Stew"))
                {
                    __instance.m_GearItemBeingCooked.m_Cookable.m_CanBePickedUpWhileCooking = false; //Disables the option to pickup a stew that is not done cooking
                }
            }
        }
    }
}