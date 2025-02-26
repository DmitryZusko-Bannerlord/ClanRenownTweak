using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.PerCampaign;

namespace ClanRenounTweak.MCM
{
    class Settings : AttributePerCampaignSettings<Settings>
    {
        private static Settings _instance;
        public static Settings Instance
        {
            get
            {
                return _instance ?? (_instance = new Settings());
            }
        }

        public override string Id => "ClanRenounTweak";

        public override string DisplayName => "Clan Renoun Tweak";

        [SettingPropertyFloatingInteger("Player renoun gain multiplier", 0.001f, 1000, "0%",
            HintText = "Multiplying coef for player renoun gains (def = 100%)", RequireRestart = false, Order = 1)]
        [SettingPropertyGroup("Renoun gain multiplier", GroupOrder = 1)]
        public float PlayerRenounMultiplier { get; set; } = 1;

        [SettingPropertyInteger("1 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired be player to reach clan tier level 1 (def = 50)", RequireRestart = false, Order = 2)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelOne { get; set; } = 50;

        [SettingPropertyInteger("2 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired be player to reach clan tier level 2 (def = 150)", RequireRestart = false, Order = 3)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelTwo { get; set; } = 150;

        [SettingPropertyInteger("3 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired be player to reach clan tier level 3 (def = 350)", RequireRestart = false, Order = 4)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelThree { get; set; } = 350;

        [SettingPropertyInteger("4 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired be player to reach clan tier level 4 (def = 900)", RequireRestart = false, Order = 5)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelFour { get; set; } = 900;

        [SettingPropertyInteger("5 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired be player to reach clan tier level 5 (def = 2350)", RequireRestart = false, Order = 6)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelFive { get; set; } = 2350;

        [SettingPropertyInteger("6 tier renoun", 1, 1000000, "0",
            HintText = "Amount of renoun to be aquired be player to reach clan tier level 6 (def = 6150)", RequireRestart = false, Order = 7)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenounLevelSix { get; set; } = 6150;
    }
}