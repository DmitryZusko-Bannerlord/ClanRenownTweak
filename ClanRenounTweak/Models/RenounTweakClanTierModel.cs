using ClanRenounTweak.MCM;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace ClanRenounTweak.Models
{
    public interface IRenounTweakClanTierModel
    {
        void RecalculateClanTiers();
        float TweakGainedRenounValue(float value, Clan clan);
    }

    class RenounTweakClanTierModel : DefaultClanTierModel, IRenounTweakClanTierModel
    {
        public void RecalculateClanTiers()
        {
            float almostZero = 0.00001f;
            foreach (var clan in Clan.All)
            {
                clan.AddRenown(almostZero);
            }
        }

        public virtual float TweakGainedRenounValue(float value, Clan clan)
        {
            var tweakSettings = ClanRenounTweakSettings.Instance;
            if (tweakSettings == null || (!tweakSettings.IsAplyClanTiersToNonPlayer && clan.Id != Clan.PlayerClan.Id))
                return value;

            return value * tweakSettings.RenounMultiplier;
        }

        public override int CalculateInitialRenown(Clan clan)
        {
            var renounTweakSettings = ClanRenounTweakSettings.Instance;
            if (renounTweakSettings == null) return base.CalculateInitialRenown(clan);

            var tierLowerRenownLimits = clan.Id == Clan.PlayerClan.Id || renounTweakSettings.IsAplyClanTiersToNonPlayer
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
            if (renounTweakSettings == null) return base.CalculateTier(clan);

            var tierLowerRenownLimits = clan.Id == Clan.PlayerClan.Id || renounTweakSettings.IsAplyClanTiersToNonPlayer
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
            if (ClanRenounTweakSettings.Instance == null) return base.GetRequiredRenownForTier(tier);

            return ClanRenounTweakSettings.Instance.TweakedTierLowerRenownLimits[tier];
        }
    }
}
