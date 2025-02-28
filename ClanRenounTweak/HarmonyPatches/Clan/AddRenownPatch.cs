using ClanRenounTweak.Models;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace ClanRenounTweak.HarmonyPatches
{
    [HarmonyPatch(typeof(Clan), "AddRenown")]
    class AddRenownPatch
    {
        public static bool Prefix(Clan __instance, ref int ____tier, float value, bool shouldNotify = true)
        {
            var tweakedClanTierModel = Campaign.Current.Models.ClanTierModel as IRenounTweakClanTierModel;
            value = tweakedClanTierModel.TweakGainedRenounValue(value, __instance);

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
