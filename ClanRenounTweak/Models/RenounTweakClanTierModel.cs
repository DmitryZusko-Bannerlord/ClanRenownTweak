using ClanRenounTweak.MCM;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace ClanRenounTweak.Models
{
    class RenounTweakClanTierModel : DefaultClanTierModel
    {
        public void RecalculateClanTiers()
        {
            float almostZero = 0.00001f;
            foreach (var clan in Clan.All)
            {
                clan.AddRenown(almostZero);
            }
        }

        public override int CalculateInitialRenown(Clan clan)
        {
            var renounTweakSettings = ClanRenounTweakSettings.Instance;
            var tierLowerRenownLimits = clan.Id == Clan.PlayerClan.Id || renounTweakSettings.IsAplyForNonPlayerClan
                ? renounTweakSettings.TweakedTierLowerRenownLimits
                : renounTweakSettings.DefaultTierLowerRenownLimits;

            int num = tierLowerRenownLimits[clan.Tier];
            int num2 = ((clan.Tier >= MaxClanTier) ? (tierLowerRenownLimits[MaxClanTier] + 1500) : tierLowerRenownLimits[clan.Tier + 1]);
            int maxValue = (int)((float)num2 - (float)(num2 - num) * 0.4f);
            return MBRandom.RandomInt(num, maxValue);
        }

        public override int CalculateTier(Clan clan)
        {
            var renounTweakSettings = ClanRenounTweakSettings.Instance;
            var tierLowerRenownLimits = clan.Id == Clan.PlayerClan.Id || renounTweakSettings.IsAplyForNonPlayerClan
                ? renounTweakSettings.TweakedTierLowerRenownLimits
                : renounTweakSettings.DefaultTierLowerRenownLimits;

            int result = MinClanTier;
            for (int i = MinClanTier + 1; i <= MaxClanTier; i++)
            {
                if (clan.Renown >= (float)tierLowerRenownLimits[i])
                {
                    result = i;
                }
            }

            return result;
        }

        public override int GetRequiredRenownForTier(int tier)
        {
            var tweakedTierLowerRenownLimits = ClanRenounTweakSettings.Instance.TweakedTierLowerRenownLimits;

            return tweakedTierLowerRenownLimits[tier];
        }
    }
}
