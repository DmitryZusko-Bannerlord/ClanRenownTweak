using ClanRenounTweak.MCM;
using ClanRenounTweak.Models;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using static ClanRenounTweak.MCM.ClanRenounTweakSettings;

namespace ClanRenounTweak
{
    class SubModule : MBSubModuleBase
    {
        private readonly static string _harmonyId = "com.goodhunter.clanrenountweak";
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
            var tweakedClanTierModel = new RenounTweakClanTierModel();
            _test = tweakedClanTierModel.RecalculateClanTiers;

            gameStarterObject.AddModel(tweakedClanTierModel);
        }

        public override void OnAfterGameInitializationFinished(Game game, object starterObject)
        {
            base.OnAfterGameInitializationFinished(game, starterObject);

            ClanRenounTweakSettings.Instance.ClanTierRelatedSettingsChanged += new ClanTierRelatedSettingsChangedHandler(_test);
        }
    }
}
