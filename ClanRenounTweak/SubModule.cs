using ClanRenounTweak.Models;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace ClanRenounTweak
{
    class SubModule : MBSubModuleBase
    {
        private readonly static string _harmonyId = "com.goodhunter.clanrenountweak";

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
            gameStarterObject.AddModel(new RenounTweakClanTierModel());
        }
    }
}
