using ClanRenownTweak.MCM;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace ClanRenownTweak.Models
{
    public interface IRenownTweakClanTierModel
    {
        void RecalculateClanTiers();
        float TweakGainedRenownValue(float value, Clan clan);
    }

    class RenownTweakClanTierModel : DefaultClanTierModel, IRenownTweakClanTierModel
    {
        public void RecalculateClanTiers()
        {
            float almostZero = 0.00001f;
            foreach (var clan in Clan.All)
            {
                clan.AddRenown(almostZero);
            }
        }

        public virtual float TweakGainedRenownValue(float value, Clan clan)
        {
            var tweakSettings = ClanRenownTweakSettings.Instance;
            if (tweakSettings == null || (!tweakSettings.IsAplyClanTiersToNonPlayer && clan.Id != Clan.PlayerClan.Id))
                return value;

            return value * tweakSettings.RenownMultiplier;
        }

        public override int CalculateInitialRenown(Clan clan)
        {
            var renownTweakSettings = ClanRenownTweakSettings.Instance;
            if (renownTweakSettings == null) return base.CalculateInitialRenown(clan);

            var tierLowerRenownLimits = clan.Id == Clan.PlayerClan.Id || renownTweakSettings.IsAplyClanTiersToNonPlayer
                ? renownTweakSettings.TweakedTierLowerRenownLimits
                : renownTweakSettings.DefaultTierLowerRenownLimits;

            int num = tierLowerRenownLimits[clan.Tier];
            int num2 = ((clan.Tier >= MaxClanTier) ? (tierLowerRenownLimits[MaxClanTier] + 1500) : tierLowerRenownLimits[clan.Tier + 1]);
            int maxValue = (int)((float)num2 - (float)(num2 - num) * 0.4f);
            return MBRandom.RandomInt(num, maxValue);
        }

        public override int CalculateTier(Clan clan)
        {
            var renownTweakSettings = ClanRenownTweakSettings.Instance;
            if (renownTweakSettings == null) return base.CalculateTier(clan);

            var tierLowerRenownLimits = clan.Id == Clan.PlayerClan.Id || renownTweakSettings.IsAplyClanTiersToNonPlayer
                ? renownTweakSettings.TweakedTierLowerRenownLimits
                : renownTweakSettings.DefaultTierLowerRenownLimits;

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
            if (ClanRenownTweakSettings.Instance == null) return base.GetRequiredRenownForTier(tier);

            return ClanRenownTweakSettings.Instance.TweakedTierLowerRenownLimits[tier];
        }
    }
}
