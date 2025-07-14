#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

namespace Water2D
{
    [ExecuteInEditMode]
    public class PhysicsSimulation : MonoBehaviour
    {
        public static PhysicsSimulation instance;

        public bool Simulate = false;
        private bool _lastSimulateState = false;
        private PhysicsScene2D _currentPhysicsScene;
        private float _timer = 0f;

        [HideInInspector]
        public List<Rigidbody2D> RBAltered = new List<Rigidbody2D>();

        private bool _alreadyCreated = false;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Debug.LogWarning("Duplicate PhysicsSimulation instance found. Destroying this instance.");
                DestroyImmediate(gameObject);
            }
        }

        public static void Run()
        {
            if (Application.isPlaying)
            {
                Debug.Log("Cannot run PhysicsSimulation in play mode.");
                return;
            }

            if (instance == null)
            {
                GameObject go = new GameObject("physim_Water2d");
                instance = go.AddComponent<PhysicsSimulation>();
            }

            instance.OnRun();
        }

        public static void Stop()
        {
            if (instance != null)
            {
                instance.OnStop();
            }
        }

        private void OnRun()
        {
            if (Simulate) return;

            Physics2D.autoSimulation = false;
            ExcludeRB2D();
            Simulate = true;
            EditorApplication.update += UpdatePhysics;
        }

        private void OnStop()
        {
            Simulate = false;
            EditorApplication.update -= UpdatePhysics;
            BackToNormalRB2D();
            Physics2D.autoSimulation = true;
        }

        private void Create()
        {
            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.GetActiveScene();
            _currentPhysicsScene = scene.GetPhysicsScene2D();
            RBAltered = new List<Rigidbody2D>(10);
            _alreadyCreated = true;
        }

        private void ExcludeRB2D()
        {
            var rbArray = FindObjectsOfType<Rigidbody2D>();
            foreach (var rb in rbArray)
            {
                if (rb.CompareTag("Water") || rb.CompareTag("Cream") || rb.CompareTag("IceCream") || 
                    rb.CompareTag("InGlassWater") || rb.CompareTag("InGlassCream") || rb.CompareTag("InGlassIceCream"))
                    continue;

                if (rb.bodyType == RigidbodyType2D.Static || rb.bodyType == RigidbodyType2D.Kinematic)
                    continue;

                rb.bodyType = RigidbodyType2D.Static;
                RBAltered.Add(rb);
            }
        }

        private void BackToNormalRB2D()
        {
            foreach (var rb in RBAltered)
            {
                if (rb != null)
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;
                }
            }
            RBAltered.Clear();
        }

        private void UpdatePhysics()
        {
            if (Application.isPlaying) return;

            if (_lastSimulateState != Simulate)
            {
                _lastSimulateState = Simulate;

                if (!_alreadyCreated)
                {
                    Create();
                }
            }

            if (Simulate)
            {
                _timer += Time.deltaTime;

                if (_currentPhysicsScene.IsValid())
                {
                    while (_timer >= Time.fixedDeltaTime)
                    {
                        _timer -= Time.fixedDeltaTime;
                        if (!Physics2D.autoSimulation)
                        {
                            _currentPhysicsScene.Simulate(Time.fixedDeltaTime);
                        }
                    }
                }
            }
        }
    }
}
#endif
