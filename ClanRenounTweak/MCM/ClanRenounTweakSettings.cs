using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.PerCampaign;

namespace ClanRenounTweak.MCM
{
    class ClanRenounTweakSettings : AttributePerCampaignSettings<ClanRenounTweakSettings>
    {
        public override string Id => "ClanRenounTweak";

        public override string DisplayName => "Clan Renoun Tweak";

        [SettingPropertyFloatingInteger("Player renoun gain multiplier", 0.001f, 1000, "0%",
            HintText = "Multiplying coef for player renoun gains (def = 100%)", RequireRestart = false, Order = 1)]
        [SettingPropertyGroup("Renoun gain multiplier", GroupOrder = 1)]
        public float PlayerRenounMultiplier { get; set; } = 1;

        [SettingPropertyInteger("1 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired to reach clan tier level 1 (def = 50)", RequireRestart = false, Order = 100)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelOne
        {
            get
            {
                return TweakedTierLowerRenownLimits[1];
            }
            set
            {
                TweakedTierLowerRenownLimits[1] = value;
            }
        }

        [SettingPropertyInteger("2 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired to reach clan tier level 2 (def = 150)", RequireRestart = false, Order = 110)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelTwo
        {
            get
            {
                return TweakedTierLowerRenownLimits[2];
            }
            set
            {
                TweakedTierLowerRenownLimits[2] = value;
            }
        }

        [SettingPropertyInteger("3 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired to reach clan tier level 3 (def = 350)", RequireRestart = false, Order = 120)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelThree
        {
            get
            {
                return TweakedTierLowerRenownLimits[3];
            }
            set
            {
                TweakedTierLowerRenownLimits[3] = value;
            }
        }

        [SettingPropertyInteger("4 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired to reach clan tier level 4 (def = 900)", RequireRestart = false, Order = 130)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelFour
        {
            get
            {
                return TweakedTierLowerRenownLimits[4];
            }
            set
            {
                TweakedTierLowerRenownLimits[4] = value;
            }
        }

        [SettingPropertyInteger("5 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired to reach clan tier level 5 (def = 2350)", RequireRestart = false, Order = 140)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelFive
        {
            get
            {
                return TweakedTierLowerRenownLimits[5];
            }
            set
            {
                TweakedTierLowerRenownLimits[5] = value;
            }
        }

        [SettingPropertyInteger("6 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired to reach clan tier level 6 (def = 6150)", RequireRestart = false, Order = 150)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelSix
        {
            get
            {
                return TweakedTierLowerRenownLimits[6];
            }
            set
            {
                TweakedTierLowerRenownLimits[6] = value;
            }
        }

        [SettingPropertyBool("Apply to non-player clans",
            HintText = "If checked, these requirements also will be applied for non-player clans", RequireRestart = false, Order = 160)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public bool IsAplyForNonPlayerClan { get; set; } = false;

        public int[] DefaultTierLowerRenownLimits = new int[] { 0, 50, 150, 350, 900, 2350, 6150 };
        public int[] TweakedTierLowerRenownLimits = new int[7];

        public ClanRenounTweakSettings()
        {
            DefaultTierLowerRenownLimits.CopyTo(TweakedTierLowerRenownLimits, 0);
        }
    }
}