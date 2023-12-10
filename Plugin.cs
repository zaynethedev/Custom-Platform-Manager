using System;
using BepInEx;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using Utilla;

namespace CubeSummoner
{
	/// <summary
	/* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		bool posSetR;
		bool posSetL;
		internal GameObject MyCubeR;
		internal Material CubeMaterialR;
		internal GameObject MyCubeL;
		internal Material CubeMaterialL;

		void Start()
		{
			/* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */
			Utilla.Events.GameInitialized += OnGameInitialized;
			MyCubeL = GameObject.CreatePrimitive(PrimitiveType.Cube);
			MyCubeL.transform.position = new Vector3(0, 0, 0);
			MyCubeR = GameObject.CreatePrimitive(PrimitiveType.Cube);
			MyCubeR.transform.position = new Vector3(0, 0, 0);
			MyCubeR.transform.localScale = new Vector3(0.5f, 0.175f, 0.5f);
			CubeMaterialR = new Material(Shader.Find("GorillaTag/UberShader"));
			MyCubeR.GetComponent<Renderer>().material = CubeMaterialR;
		}

		void OnEnable()
		{
			/* Set up your mod here */
			/* Code here runs at the start and whenever your mod is enabled*/
		}

		void OnDisable()
		{
			/* Undo mod setup here */
			/* This provides support for toggling mods with ComputerInterface, please implement it :) */
			/* Code here runs whenever your mod is disabled (including if it disabled on startup)*/
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			/* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
		}

		void Update()
		{
			/* Code here runs every frame when the mod is enabled */
			if (inRoom)
			{
				if (ControllerInputPoller.instance.rightControllerGripFloat >= 0.5f)
				{
					while (posSetR == false)
					{
						GorillaTagger.Instance.rightHandTransform.position = MyCubeR.transform.position;
						posSetR = true;
					}
					MyCubeR.transform.position = GorillaTagger.Instance.rightHandTransform.position;
				}
				else
				{
					posSetR = false;
                    MyCubeR.transform.position = new Vector3(0, 0, 0);
				},
				if (ControllerInputPoller.instance.leftControllerGripFloat >= 0.5f)
				{
					while (posSetL == false)
					{
						GorillaTagger.Instance.leftHandTransform.position = MyCubeL.transform.position;
						posSetL = true;
					}
					MyCubeL.transform.position = GorillaTagger.Instance.leftHandTransform.position;
				}
				else
				{
					posSetL = false;
                    MyCubeL.transform.position = new Vector3(0, 0, 0);
				}
			}
		}

		/* This attribute tells Utilla to call this method when a modded room is joined */
		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			/* Activate your mod here */
			/* This code will run regardless of if the mod is enabled*/
			/* Make sure all code is going to be here or else your mod will be considered a cheat.*/
			inRoom = true;
		}

		/* This attribute tells Utilla to call this method when a modded room is left */
		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			/* Deactivate your mod here */
			/* This code will run regardless of if the mod is enabled*/

			inRoom = false;
		}
	}
}
