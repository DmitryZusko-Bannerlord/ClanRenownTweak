using ClanRenounTweak.MCM;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace ClanRenounTweak.Models
{
    /*class RenounTweakClanTierModel : DefaultClanTierModel
    {
        private static RenounTweakClanTierModel _instance;
        public static RenounTweakClanTierModel Instance
        {
            get
            {
                return _instance ?? (_instance = new RenounTweakClanTierModel());
            }
        }

        public RenounTweakClanTierModel()
        {

        }

        public virtual int GetRequiredRenownForTier(int clanTier, bool isPlayerClan)
        {
            var settings = ClanRenounTweakSettings.Instance;
            if (settings == null) return Campaign.Current.Models.ClanTierModel.GetRequiredRenownForTier(clanTier);

            if (isPlayerClan || !settings.IsApplyClanTiersOnlyToPlayer) return CalculateCustomRenounForTier(settings, clanTier);

            return Campaign.Current.Models.ClanTierModel.GetRequiredRenownForTier(clanTier);
        }

        protected virtual int CalculateCustomRenounForTier(ClanRenounTweakSettings settings, int clanTier)
        {
            switch (clanTier)
            {
                case 1:
                    {
                        return settings.ClanRenounLevelOne;
                    }
                case 2:
                    {
                        return settings.ClanRenounLevelTwo;
                    }
                case 3:
                    {
                        return settings.ClanRenounLevelThree;
                    }
                case 4:
                    {
                        return settings.ClanRenounLevelFour;
                    }
                case 5:
                    {
                        return settings.ClanRenounLevelFive;
                    }
                case 6:
                    {
                        return settings.ClanRenounLevelSix;
                    }
            }
            return 0;
        }
    }*/

    class RenounTweakClanTierModel : DefaultClanTierModel
    {
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
