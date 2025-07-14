using UnityEngine;
using System.Collections;
using Water2D;
using UnityEditor;

public class GraphicsSettings : MonoBehaviour
{
	// GRAPHICS

	GameObject ScratchTerrain;
	GameObject Terrain;
	public GameObject Liquid;
	Generators Generators;
	public GameObject Ribbon1;
	public GameObject Ribbon2;
	public GameObject Ribbon3;
	public GameObject DirectionalLight;
	public GameObject EffectQuad;
	// GRAPHICS





	void Awake()
	{
		Generators=GameObject.FindGameObjectWithTag("Generators").GetComponent<Generators>();

		Terrain = GameObject.FindGameObjectWithTag("Terrain");

		ScratchTerrain = GameObject.FindGameObjectWithTag("ScratchTerrain");



		// LOW
		if (QualitySettings.GetQualityLevel() == 0)
		{
			// GENERATORS
			// WATER GENERATOR
			Generators.Water_AlphaCutOff = 0f;
			Generators.Water_AlphaStroke = 0f;
			Generators.Water_TrailStartSize = 0f;
			Generators.Water_TrailEndSize = 0f;
			Generators.Water_TrailDelay = 0f;
			Generators.Water_size = 0.07f;
			Generators.Water_DelayBetweenParticles = 0.025f;

			// CREAM GENERATOR
			Generators.Cream_AlphaCutOff = 0f;
			Generators.Cream_AlphaStroke = 0f;
			Generators.Cream_TrailStartSize = 0f;
			Generators.Cream_TrailEndSize = 0f;
			Generators.Cream_TrailDelay = 0f;
			Generators.Cream_size = 0.07f;
			Generators.Cream_DelayBetweenParticles = 0.025f;

			// ICECREAM GENERATOR
			Generators.IceCream_AlphaCutOff = 0f;
			Generators.IceCream_AlphaStroke = 0f;
			Generators.IceCream_TrailStartSize = 0f;
			Generators.IceCream_TrailEndSize = 0f;
			Generators.IceCream_TrailDelay = 0f;
			Generators.IceCream_size = 0.07f;
			Generators.IceCream_DelayBetweenParticles = 0.025f;


			// LAVA GENERATOR
			Generators.Hot_AlphaCutOff = 0f;
			Generators.Hot_AlphaStroke = 0f;
			Generators.Hot_TrailStartSize = 0f;
			Generators.Hot_TrailEndSize = 0f;
			Generators.Hot_TrailDelay = 0f;
			Generators.Hot_size = 0.07f;
			Generators.Hot_DelayBetweenParticles = 0.025f;
			// GENERATORS


			// LIQUID DROP
			Liquid.GetComponent<MetaballParticleClass>().enabled = false;
			Liquid.GetComponent<TrailRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
			Liquid.GetComponent<TrailRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
			Liquid.GetComponent<TrailRenderer>().allowOcclusionWhenDynamic = false;
			// LIQUID DROP

/*
			// ScratchTerrain
			if (ScratchTerrain != null)
				for (int a = 0; a < ScratchTerrain.transform.childCount; a++)
				{
					if (ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().blockSize = 1f;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().simplifyEpsilonPercent = 0f;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().resolutionX = 6;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().resolutionY = 10;
					}
					else if (ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>().segmentCount = 10;
						ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>().touchMoveDistance = 0.05f;

					}
					else if (ScratchTerrain.transform.GetChild(a).GetComponent<AwakeCircleClipper>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<AwakeCircleClipper>().segmentCount = 10;

					}

				}
			// ScratchTerrain
*/

			// Terrain
			if(Terrain!=null)
			for (int a = 0; a < Terrain.transform.childCount; a++)
			{
				if (Terrain.transform.GetChild(a).GetComponent<Ferr2DT_PathTerrain>() != null)
				{
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().receiveShadows = false;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;


				}
			}
			// Terrain



			// Ribbon
			Ribbon1.GetComponent<ParticleSystem>().maxParticles = 10;
			for (int a = 0; a < Ribbon1.transform.childCount; a++)
			{
				Ribbon1.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 10;
			}
			Ribbon2.GetComponent<ParticleSystem>().maxParticles = 10;
			for (int a = 0; a < Ribbon2.transform.childCount; a++)
			{
				Ribbon2.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 10;
			}
			Ribbon3.GetComponent<ParticleSystem>().maxParticles = 10;
			for (int a = 0; a < Ribbon3.transform.childCount; a++)
			{
				Ribbon3.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 10;
			}
			// Ribbon




			// DirectionalLight
			DirectionalLight.GetComponent<Light>().shadows = LightShadows.None;
			DirectionalLight.GetComponent<Light>().renderMode = LightRenderMode.ForceVertex;
			// DirectionalLight

			// EffectQuad
			EffectQuad.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			EffectQuad.GetComponent<MeshRenderer>().receiveShadows = false;
			EffectQuad.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
			EffectQuad.GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
			EffectQuad.GetComponent<ResizeQuadEffectController>().enabled = true;
			// EffectQuad

		}
		// MEDIUM
		else if (QualitySettings.GetQualityLevel() == 1)
		{
			// GENERATORS
			// WATER GENERATOR
			Generators.Water_AlphaCutOff = 0.5f;
			Generators.Water_AlphaStroke = 4f;
			Generators.Water_TrailStartSize = 0.4f;
			Generators.Water_TrailEndSize = 0.3f;
			Generators.Water_TrailDelay = 0.1f;
			Generators.Water_size = 0.07f;
			Generators.Water_DelayBetweenParticles = 0.025f;

			// CREAM GENERATOR
			Generators.Cream_AlphaCutOff = 0.5f;
			Generators.Cream_AlphaStroke = 2f;
			Generators.Cream_TrailStartSize = 0.4f;
			Generators.Cream_TrailEndSize = 0f;
			Generators.Cream_TrailDelay = 0.1f;
			Generators.Cream_size = 0.07f;
			Generators.Cream_DelayBetweenParticles = 0.025f;

			// ICECREAM GENERATOR
			Generators.IceCream_AlphaCutOff = 0.5f;
			Generators.IceCream_AlphaStroke = 2f;
			Generators.IceCream_TrailStartSize = 0.4f;
			Generators.IceCream_TrailEndSize = 0.3f;
			Generators.IceCream_TrailDelay = 0.1f;
			Generators.IceCream_size = 0.07f;
			Generators.IceCream_DelayBetweenParticles = 0.025f;

			// LAVA GENERATOR
			Generators.Hot_AlphaCutOff = 0.5f;
			Generators.Hot_AlphaStroke = 2f;
			Generators.Hot_TrailStartSize = 0.4f;
			Generators.Hot_TrailEndSize = 0f;
			Generators.Hot_TrailDelay = 0.1f;
			Generators.Hot_size = 0.07f;
			Generators.Hot_DelayBetweenParticles = 0.025f;
			// GENERATORS


			// LIQUID DROP
			Liquid.GetComponent<MetaballParticleClass>().enabled = true;
			Liquid.GetComponent<TrailRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.BlendProbes;
			Liquid.GetComponent<TrailRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Simple;
			Liquid.GetComponent<TrailRenderer>().allowOcclusionWhenDynamic = true;
			// LIQUID DROP


/*
			// ScratchTerrain
			if (ScratchTerrain != null)
				for (int a = 0; a < ScratchTerrain.transform.childCount; a++)
				{
					if (ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().blockSize = 1f;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().simplifyEpsilonPercent = 3f;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().resolutionX = 6;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().resolutionY = 10;
					}
					else if (ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>().segmentCount = 20;
						ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>().touchMoveDistance = 0.03f;

					}
					else if (ScratchTerrain.transform.GetChild(a).GetComponent<AwakeCircleClipper>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<AwakeCircleClipper>().segmentCount = 20;

					}

				}
			// ScratchTerrain
*/

			// Terrain
			if(Terrain!=null)
			for (int a = 0; a < Terrain.transform.childCount; a++)
			{
				if (Terrain.transform.GetChild(a).GetComponent<Ferr2DT_PathTerrain>() != null)
				{
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().receiveShadows = true;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.BlendProbes;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Simple;


				}
			}
			// Terrain



			// Ribbon
			Ribbon1.GetComponent<ParticleSystem>().maxParticles = 100;
			for (int a = 0; a < Ribbon1.transform.childCount; a++)
			{
				Ribbon1.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 100;
			}
			Ribbon2.GetComponent<ParticleSystem>().maxParticles = 100;
			for (int a = 0; a < Ribbon2.transform.childCount; a++)
			{
				Ribbon2.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 100;
			}
			Ribbon3.GetComponent<ParticleSystem>().maxParticles = 100;
			for (int a = 0; a < Ribbon3.transform.childCount; a++)
			{
				Ribbon3.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 100;
			}
			// Ribbon




			// DirectionalLight
			DirectionalLight.GetComponent<Light>().shadows = LightShadows.Hard;
			DirectionalLight.GetComponent<Light>().renderMode = LightRenderMode.Auto;
			// DirectionalLight

			// EffectQuad
			EffectQuad.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			EffectQuad.GetComponent<MeshRenderer>().receiveShadows = true;
			EffectQuad.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.BlendProbes;
			EffectQuad.GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Simple;
			EffectQuad.GetComponent<ResizeQuadEffectController>().enabled = true;
			// EffectQuad

		}
		// HIGH
		else if (QualitySettings.GetQualityLevel() == 2)
		{
			// GENERATORS
			// WATER GENERATOR
			Generators.Water_AlphaCutOff = 0.5f;
			Generators.Water_AlphaStroke = 6f;
			Generators.Water_TrailStartSize = 0.4f;
			Generators.Water_TrailEndSize = 0.3f;
			Generators.Water_TrailDelay = 0.2f;
			Generators.Water_size = 0.07f;
			Generators.Water_DelayBetweenParticles = 0.025f;

			// CREAM GENERATOR
			Generators.Cream_AlphaCutOff = 0.7f;
			Generators.Cream_AlphaStroke = 4f;
			Generators.Cream_TrailStartSize = 0.4f;
			Generators.Cream_TrailEndSize = 0f;
			Generators.Cream_TrailDelay = 0.2f;
			Generators.Cream_size = 0.07f;
			Generators.Cream_DelayBetweenParticles = 0.025f;

			// ICECREAM GENERATOR
			Generators.IceCream_AlphaCutOff = 0.7f;
			Generators.IceCream_AlphaStroke = 4f;
			Generators.IceCream_TrailStartSize = 0.4f;
			Generators.IceCream_TrailEndSize = 0.3f;
			Generators.IceCream_TrailDelay = 0.2f;
			Generators.IceCream_size = 0.07f;
			Generators.IceCream_DelayBetweenParticles = 0.025f;

			// LAVA GENERATOR
			Generators.Hot_AlphaCutOff = 0.7f;
			Generators.Hot_AlphaStroke = 4f;
			Generators.Hot_TrailStartSize = 0.4f;
			Generators.Hot_TrailEndSize = 0f;
			Generators.Hot_TrailDelay = 0.2f;
			Generators.Hot_size = 0.07f;
			Generators.Hot_DelayBetweenParticles = 0.025f;
			// GENERATORS


			// LIQUID DROP
			Liquid.GetComponent<MetaballParticleClass>().enabled = true;
			Liquid.GetComponent<TrailRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.BlendProbes;
			Liquid.GetComponent<TrailRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.BlendProbesAndSkybox;
			Liquid.GetComponent<TrailRenderer>().allowOcclusionWhenDynamic = true;
			// LIQUID DROP


/*
			// ScratchTerrain
			if (ScratchTerrain != null)
				for (int a = 0; a < ScratchTerrain.transform.childCount; a++)
				{
					if (ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().blockSize = 0.5f;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().simplifyEpsilonPercent = 3f;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().resolutionX = 12;
						ScratchTerrain.transform.GetChild(a).GetComponent<DestructibleTerrain>().resolutionY = 20;
					}
					else if (ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>().segmentCount = 20;
						ScratchTerrain.transform.GetChild(a).GetComponent<RuntimeCircleClipper>().touchMoveDistance = 0.01f;

					}
					else if (ScratchTerrain.transform.GetChild(a).GetComponent<AwakeCircleClipper>() != null)
					{
						ScratchTerrain.transform.GetChild(a).GetComponent<AwakeCircleClipper>().segmentCount = 20;

					}

				}
			// ScratchTerrain
*/

			// Terrain
			if(Terrain!=null)
			for (int a = 0; a < Terrain.transform.childCount; a++)
			{
				if (Terrain.transform.GetChild(a).GetComponent<Ferr2DT_PathTerrain>() != null)
				{
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().receiveShadows = true;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.BlendProbes;
					Terrain.transform.GetChild(a).GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Simple;


				}
			}
			// Terrain



			// Ribbon
			Ribbon1.GetComponent<ParticleSystem>().maxParticles = 1000;
			for (int a = 0; a < Ribbon1.transform.childCount; a++)
			{
				Ribbon1.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 1000;
			}
			Ribbon2.GetComponent<ParticleSystem>().maxParticles = 1000;
			for (int a = 0; a < Ribbon2.transform.childCount; a++)
			{
				Ribbon2.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 1000;
			}
			Ribbon3.GetComponent<ParticleSystem>().maxParticles = 1000;
			for (int a = 0; a < Ribbon3.transform.childCount; a++)
			{
				Ribbon3.transform.GetChild(a).gameObject.GetComponent<ParticleSystem>().maxParticles = 1000;
			}
			// Ribbon




			// DirectionalLight
			DirectionalLight.GetComponent<Light>().shadows = LightShadows.Hard;
			DirectionalLight.GetComponent<Light>().renderMode = LightRenderMode.Auto;
			// DirectionalLight

			// EffectQuad
			EffectQuad.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			EffectQuad.GetComponent<MeshRenderer>().receiveShadows = true;
			EffectQuad.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.BlendProbes;
			EffectQuad.GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Simple;
			EffectQuad.GetComponent<ResizeQuadEffectController>().enabled = true;
			// EffectQuad

		}

	}


	// FPS
	float deltaTime = 0.0f;
	// FPS

	void Update()
	{
		// FPS
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		// FPS
	}









	// FPS
	void OnGUI()
	{

		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 60;
		style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		float fps = 1.0f / deltaTime;
		string text = string.Format("FPS: {0:0.}", fps);
		GUI.Label(rect, text, style);
	}
	// FPS
}