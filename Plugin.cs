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
		bool platSetR;
		bool platSetL;
		internal GameObject CustomPlatR;
		internal Material CubeMaterialR;
		internal GameObject CustomPlatL;
		internal Material CubeMaterialL;

		void Start()
		{
			/* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */
			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			/* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
			//create cubes
			CustomPlatL = GameObject.CreatePrimitive(PrimitiveType.Cube);
			CustomPlatL.transform.position = new Vector3(0, 0, 0);
			CustomPlatR = GameObject.CreatePrimitive(PrimitiveType.Cube);
			CustomPlatR.transform.position = new Vector3(0, 0, 0);
			//set cube name
			CustomPlatL.name = "CustomPlatL";
			CustomPlatR.name = "CustomPlatR";
			//set cube size
			CustomPlatR.transform.localScale = new Vector3(0.25f, 0.04f, 0.25f);
			CustomPlatL.transform.localScale = new Vector3(0.25f, 0.04f, 0.25f);
			//make cube visible
			CubeMaterialR = new Material(Shader.Find("GorillaTag/UberShader"));
			CubeMaterialL = new Material(Shader.Find("GorillaTag/UberShader"));
			CustomPlatR.GetComponent<Renderer>().material = CubeMaterialR;
			CustomPlatL.GetComponent<Renderer>().material = CubeMaterialL;
			//make cube real
			Instantiate(CustomPlatL);
			Instantiate(CustomPlatR);
		}
		void Update()
		{
			/* Code here runs every frame when the mod is enabled */
			if (inRoom)
			{
				//right controller
				if (ControllerInputPoller.instance.rightControllerGripFloat >= 0.5f)
				{
					if (platSetR == false)
					{
						CustomPlatR.transform.eulerAngles = new Vector3(GorillaLocomotion.Player.Instance.rightControllerTransform.eulerAngles.x + 90, GorillaLocomotion.Player.Instance.rightControllerTransform.eulerAngles.y, GorillaLocomotion.Player.Instance.rightControllerTransform.eulerAngles.z);
						platSetR = true;
					}
					CustomPlatR.transform.position = new Vector3(GorillaLocomotion.Player.Instance.rightControllerTransform.position.x, GorillaLocomotion.Player.Instance.rightControllerTransform.position.y, GorillaLocomotion.Player.Instance.rightControllerTransform.position.z);
				}
				else
				{
					platSetR = false;
					CustomPlatR.transform.position = new Vector3(0, 0, 0);
					CustomPlatR.transform.eulerAngles = new Vector3(0, 0, 0);
				}
				//left controller
				if (ControllerInputPoller.instance.leftControllerGripFloat >= 0.5f)
				{
					if (platSetL == false)
					{
						CustomPlatL.transform.eulerAngles = new Vector3(GorillaLocomotion.Player.Instance.leftControllerTransform.eulerAngles.x, GorillaLocomotion.Player.Instance.leftControllerTransform.eulerAngles.y, GorillaLocomotion.Player.Instance.leftControllerTransform.eulerAngles.z);
						CustomPlatL.transform.position = new Vector3(GorillaLocomotion.Player.Instance.leftControllerTransform.position.x, GorillaLocomotion.Player.Instance.leftControllerTransform.position.y, GorillaLocomotion.Player.Instance.leftControllerTransform.position.z);
						platSetL = true;
					}
				}
				else
				{
					platSetL = false;
					CustomPlatL.transform.position = new Vector3(0, 0, 0);
					CustomPlatL.transform.eulerAngles = new Vector3(0, 0, 0);
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
