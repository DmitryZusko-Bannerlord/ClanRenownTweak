using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.PerCampaign;
using System.Runtime.CompilerServices;

namespace ClanRenounTweak.MCM
{
    class ClanRenounTweakSettings : AttributePerCampaignSettings<ClanRenounTweakSettings>
    {
        private bool _isClanRelatedSettingChanged = false;

        private bool _IsAplyForNonPlayerClan = false;

        public override string Id => "ClanRenounTweak";

        public override string DisplayName => "Clan Renoun Tweak";

        [SettingPropertyFloatingInteger("Renoun gain multiplier", 0.001f, 1000, "0%",
            HintText = "Multiplying coef for renoun gains from all sources (def = 100%)", RequireRestart = false, Order = 10)]
        [SettingPropertyGroup("Renoun gain multiplier", GroupOrder = 1)]
        public float RenounMultiplier { get; set; } = 1;

        [SettingPropertyBool("Apply to non-player characters",
            HintText = "If checked, this multiplier also will be applied to all future renown gains of non-player characters",
            RequireRestart = false, Order = 20)]
        [SettingPropertyGroup("Renoun gain multiplier", GroupOrder = 1)]
        public bool IsApplyRenounMultiplierToNonPlayer { get; set; } = false;

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
                _isClanRelatedSettingChanged = true;
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
                _isClanRelatedSettingChanged = true;
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
                _isClanRelatedSettingChanged = true;
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
                _isClanRelatedSettingChanged = true;
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
                _isClanRelatedSettingChanged = true;
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
                _isClanRelatedSettingChanged = true;
            }
        }

        [SettingPropertyBool("Apply to non-player clans",
            HintText = "If checked, these requirements also will be applied for non-player clans", RequireRestart = false, Order = 160)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public bool IsAplyClanTiersToNonPlayer
        {
            get
            {
                return _IsAplyForNonPlayerClan;
            }
            set
            {
                _IsAplyForNonPlayerClan = value;
                _isClanRelatedSettingChanged = true;
            }
        }

        public int[] DefaultTierLowerRenownLimits = new int[] { 0, 50, 150, 350, 900, 2350, 6150 };

        public int[] TweakedTierLowerRenownLimits = new int[7];

        public delegate void ClanTierRelatedSettingsChangedHandler();

        public event ClanTierRelatedSettingsChangedHandler ClanTierRelatedSettingsChanged;

        public ClanRenounTweakSettings()
        {
            DefaultTierLowerRenownLimits.CopyTo(TweakedTierLowerRenownLimits, 0);
        }

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (!_isClanRelatedSettingChanged) return;

            ClanTierRelatedSettingsChanged?.Invoke();
            _isClanRelatedSettingChanged = false;
        }
    }
}