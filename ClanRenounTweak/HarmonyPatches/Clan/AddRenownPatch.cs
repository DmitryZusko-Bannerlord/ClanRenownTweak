using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace ClanRenounTweak.HarmonyPatches
{
    [HarmonyPatch(typeof(Clan), "AddRenown")]
    class AddRenownPatch
    {
        public static bool Prefix(Clan __instance, ref int ____tier, float value, bool shouldNotify = true)
        {
            if (value > 0f)
            {
                __instance.Renown += value;
                int num = Campaign.Current.Models.ClanTierModel.CalculateTier(__instance);

                ____tier = num;
                CampaignEventDispatcher.Instance.OnClanTierChanged(__instance, shouldNotify);
            }

            return false;
        }
    }
}
