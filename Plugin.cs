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
			MyCubeL.transform.localScale = new Vector3(0.5f, 0.175f, 0.5f);
			CubeMaterialR = new Material(Shader.Find("GorillaTag/UberShader"));
			CubeMaterialL = new Material(Shader.Find("GorillaTag/UberShader"));
			MyCubeR.GetComponent<Renderer>().material = CubeMaterialR;
			MyCubeL.GetComponent<Renderer>().material = CubeMaterialL;
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
					if (posSetR == false)
					{
						MyCubeR.transform.position = new Vector3(GorillaTagger.Instance.rightHandTransform.position.x, GorillaTagger.Instance.rightHandTransform.position.y, GorillaTagger.Instance.rightHandTransform.position.z);
						posSetR = true;
					}
					GorillaTagger.Instance.rightHandTransform.position = new Vector3(MyCubeR.transform.position.x, MyCubeR.transform.position.y, MyCubeR.transform.position.z);
				}
				else
				{
					posSetR = false;
					MyCubeR.transform.position = new Vector3(0, 0, 0);
				}
				if (ControllerInputPoller.instance.leftControllerGripFloat >= 0.5f)
				{
					if (posSetL == false)
					{
						MyCubeL.transform.position = new Vector3(GorillaTagger.Instance.leftHandTransform.position.x, GorillaTagger.Instance.leftHandTransform.position.y, GorillaTagger.Instance.leftHandTransform.position.z);
						posSetL = true;
					}
					GorillaTagger.Instance.leftHandTransform.position = new Vector3(MyCubeL.transform.position.x, MyCubeL.transform.position.y, MyCubeL.transform.position.z);
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
