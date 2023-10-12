using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using LLHandlers;
using GameplayEntities;
using LLGUI;
using LLScreen;
using Abilities;
using System.Reflection;
using System.Reflection.Emit;
using BepInEx.Logging;
using BepInEx.Configuration;
using LLBML;
using LLBML.States;
using LLBML.Utils;
using LLBML.Math;
using LLBML.Players;
using LLBML.Networking;



namespace lobbysettingsunlocked
{
	[BepInPlugin("us.wallace.plugins.llb.lobbysettingsunlocked", "lobbysettingsunlocked Plug-In", "1.0.0.0")]
	[BepInDependency(LLBML.PluginInfos.PLUGIN_ID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("no.mrgentle.plugins.llb.modmenu", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInProcess("LLBlaze.exe")]

    public class Plugin : BaseUnityPlugin

    {
		public static ManualLogSource Log { get; private set; } = null;

		void Awake()
        {

			Log = this.Logger;
			
			Logger.LogDebug("Patching effects settings...");



            var harmony = new Harmony("us.wallace.plugins.llb.lobbysettingsunlocked");

			

				harmony.PatchAll(typeof(ScreenPlayersSettingsOnOpenPatch));
			harmony.PatchAll(typeof(ScreenPlayersSettingsUpdateBallTypenPatch));



			Logger.LogDebug("lobbysettingsunlocked is loaded");
		}

		void Start()
		{

			
		}

		 void FixedUpdate()
		{
			
		}


		}

		class ScreenPlayersSettingsOnOpenPatch
	{
		[HarmonyPatch(typeof(ScreenPlayersSettings), nameof(ScreenPlayersSettings.OnOpen))]
		[HarmonyPrefix]
		public static bool OnOpen_Prefix(ScreenPlayersSettings __instance)
		{
			
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			bool flag4 = true;
			global::GameMode pnjokaicmnn = global::LLScreen.ScreenPlayersSettings.curGameSettings.PNJOKAICMNN;
			switch (pnjokaicmnn)
			{
				case global::GameMode.COMPETITIVE:
					flag = true;
					flag2 = true;
					flag3 = true;
					flag4 = true;
					goto IL_62;
				case global::GameMode.STRIKERS:
					flag = true;
					flag2 = true;
					flag3 = true;
					flag4 = true;
					goto IL_62;
				case global::GameMode.VOLLEYBALL:
					flag = true;
					flag2 = true;
					flag3 = true;
					flag4 = true;
					goto IL_62;
			}
			if (pnjokaicmnn == global::GameMode.TRAINING)
			{
				flag = true;
				flag2 = true;
				flag3 = true;
				flag4 = true;
			}
		IL_62:
			__instance.btStocks.SetEnabled(flag);
			__instance.btTime.SetEnabled(flag);
			if (flag)
			{
				__instance.btStocks.onClick = delegate (int playerNr)
				{
					__instance.BtStocksClick();
				};
				__instance.btStocks.onChange = delegate (int playerNr, int delta)
				{
					__instance.BtStocksChange(delta);
				};
				__instance.btTime.onClick = delegate (int playerNr)
				{
					__instance.BtTimeClick();
				};
				__instance.btTime.onChange = delegate (int playerNr, int delta)
				{
					__instance.BtTimeChange(delta);
				};
			}
			__instance.btHpFactor.SetEnabled(flag2);
			if (flag2)
			{
				__instance.btHpFactor.onClick = delegate (int playerNr)
				{
					__instance.BtHpFactorClick();
				};
				__instance.btHpFactor.onChange = delegate (int playerNr, int delta)
				{
					__instance.BtHpFactorChange(delta);
				};
			}
			if (global::JOMBNFKIHIC.ALEJJFPNIDP)
			{
				flag3 = true;
			}
			__instance.btPowerupSelection.SetEnabled(flag3);
			if (flag3)
			{
				__instance.btPowerupSelection.onClick = delegate (int playerNr)
				{
					__instance.BtPowerupSelectionClick();
				};
				__instance.btPowerupSelection.onChange = delegate (int playerNr, int delta)
				{
					__instance.BtPowerupSelectionChange(delta);
				};
			}
			__instance.btBallType.SetEnabled(flag4);
			if (flag4)
			{
				__instance.btBallType.onClick = delegate (int playerNr)
				{
					__instance.BtBallTypeClick(1);
				};
				__instance.btBallType.onChange = delegate (int playerNr, int delta)
				{
					__instance.BtBallTypeChange(delta);
				};
			}
			else
			{
				__instance.btBallType.gameObject.SetActive(false);
			}
			__instance.btSpeed.onChange = delegate (int playerNr, int delta)
			{
				__instance.BtSpeedChange(delta);
			};
			__instance.btSpeed.onClick = delegate (int playerNr)
			{
				__instance.BtSpeedClick();
			};
			__instance.btEnergy.onChange = delegate (int playerNr, int delta)
			{
				__instance.BtEnergyChange(delta, 1);
			};
			__instance.btEnergy.onClick = delegate (int playerNr)
			{
				__instance.BtEnergyClick();
			};

			__instance.btTag.onClick = delegate (int playerNr)
			{
				__instance.ChangeSetting(global::GameSetting.BALL_TAGGING,  !global::LLScreen.ScreenPlayersSettings.curGameSettings.BNGBHJDEJNC);
			};

			__instance.btPowerupSelection.onClick = delegate (int playerNr)
				{
					__instance.BtPowerupSelectionClick();
				};
				__instance.btPowerupSelection.onChange = delegate (int playerNr, int delta)
				{
					__instance.BtPowerupSelectionChange(delta);
				};


			__instance.btReset.onClick = delegate (int playerNr)
			{
				global::DNPFJHMAIBP.GKBNNFEAJGO(global::Msg.SEL_RESET, playerNr, -1);
			};
			__instance.btBack.onClick = delegate (int playerNr)
			{
				global::DNPFJHMAIBP.GKBNNFEAJGO(global::Msg.BACK, playerNr, -1);
			};
			__instance.UpdateSettingTexts();
			__instance.msgEsc = (__instance.msgMenu = (__instance.msgCancel = global::Msg.BACK));
			return false;
			
		}
	}


	class ScreenPlayersSettingsUpdateBallTypenPatch
	{
		[HarmonyPatch(typeof(ScreenPlayersSettings), nameof(ScreenPlayersSettings.UpdateBallType))]
		[HarmonyPrefix]
		public static bool UpdateBallType_Prefix(ScreenPlayersSettings __instance, global::BallType ballType)
		{
			__instance.btSpeed.SetEnabled(ballType != global::BallType._SELECTION_MAX);
			__instance.btPowerupSelection.SetEnabled(ballType != global::BallType._SELECTION_MAX);
			return false;

		}
	}


}
