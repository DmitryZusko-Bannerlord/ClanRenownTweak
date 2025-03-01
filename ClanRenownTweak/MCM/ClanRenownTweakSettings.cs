using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.PerCampaign;
using System.Runtime.CompilerServices;

namespace ClanRenownTweak.MCM
{
    class ClanRenownTweakSettings : AttributePerCampaignSettings<ClanRenownTweakSettings>
    {
        private bool _isClanRelatedSettingChanged = false;

        private bool _IsAplyForNonPlayerClan = false;

        public override string Id => "ClanRenownTweak";

        public override string DisplayName => "Clan Renown Tweak";

        [SettingPropertyFloatingInteger("Renown gain multiplier", 0.001f, 1000, "0%",
            HintText = "Multiplying coef for renown gains from all sources (def = 100%)", RequireRestart = false, Order = 10)]
        [SettingPropertyGroup("Renown gain multiplier", GroupOrder = 1)]
        public float RenownMultiplier { get; set; } = 1;

        [SettingPropertyBool("Apply to non-player characters",
            HintText = "If checked, this multiplier also will be applied to all future renown gains of non-player characters",
            RequireRestart = false, Order = 20)]
        [SettingPropertyGroup("Renown gain multiplier", GroupOrder = 1)]
        public bool IsApplyRenownMultiplierToNonPlayer { get; set; } = false;

        [SettingPropertyInteger("1 tier renown", 1, 1000000, "0",
            HintText = "Amount of renown to be aquired to reach clan tier level 1 (def = 50)", RequireRestart = false, Order = 100)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenownLevelOne
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

        [SettingPropertyInteger("2 tier renown", 1, 1000000, "0",
            HintText = "Amount of renown to be aquired to reach clan tier level 2 (def = 150)", RequireRestart = false, Order = 110)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenownLevelTwo
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

        [SettingPropertyInteger("3 tier renown", 1, 1000000, "0",
            HintText = "Amount of renown to be aquired to reach clan tier level 3 (def = 350)", RequireRestart = false, Order = 120)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenownLevelThree
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

        [SettingPropertyInteger("4 tier renown", 1, 1000000, "0",
            HintText = "Amount of renown to be aquired to reach clan tier level 4 (def = 900)", RequireRestart = false, Order = 130)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenownLevelFour
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

        [SettingPropertyInteger("5 tier renown", 1, 1000000, "0",
            HintText = "Amount of renown to be aquired to reach clan tier level 5 (def = 2350)", RequireRestart = false, Order = 140)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenownLevelFive
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

        [SettingPropertyInteger("6 tier renown", 1, 1000000, "0",
            HintText = "Amount of renown to be aquired to reach clan tier level 6 (def = 6150)", RequireRestart = false, Order = 150)]
        [SettingPropertyGroup("Clan tiers", GroupOrder = 2)]
        public int ClanRenownLevelSix
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

        public ClanRenownTweakSettings()
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