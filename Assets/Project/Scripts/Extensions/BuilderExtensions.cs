using JetBrains.Annotations;
using System;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;


namespace Project.Scripts.Extensions
{
    public static class BuilderExtensions
    {
        public static GameObject InstantiateWithScope([NotNull] this LifetimeScope scope, [NotNull] GameObject prefab, Transform parent = null)
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));
            
            var prefabActive = prefab.activeSelf;
            prefab.SetActive(false);

            using var disposable = LifetimeScope.EnqueueParent(scope);
            var instance = Object.Instantiate(prefab, parent);

            try
            {
                if (!instance.TryGetComponent<LifetimeScope>(out _))
                    scope.Container.InjectGameObject(instance);
            }
            finally
            {
                instance.SetActive(prefabActive);
                prefab.SetActive(prefabActive);
            }

            return instance;
        }
    }
}