using ClanRenownTweak.MCM;
using ClanRenownTweak.Models;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using static ClanRenownTweak.MCM.ClanRenownTweakSettings;

namespace ClanRenownTweak
{
    class SubModule : MBSubModuleBase
    {
        private readonly static string _harmonyId = "com.goodhunter.clanrenowntweak";
        private Action _test;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            var harmony = new Harmony(_harmonyId);
            harmony.PatchAll();
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (gameStarterObject is CampaignGameStarter)
                RegisterModels(gameStarterObject);
        }

        protected virtual void RegisterModels(IGameStarter gameStarterObject)
        {
            var tweakedClanTierModel = new RenownTweakClanTierModel();
            _test = tweakedClanTierModel.RecalculateClanTiers;

            gameStarterObject.AddModel(tweakedClanTierModel);
        }

        public override void OnAfterGameInitializationFinished(Game game, object starterObject)
        {
            base.OnAfterGameInitializationFinished(game, starterObject);

            ClanRenownTweakSettings.Instance.ClanTierRelatedSettingsChanged += new ClanTierRelatedSettingsChangedHandler(_test);
        }
    }
}
