namespace ModelGen.Shared.Tests.DataGeneration;

  public class DataGenerator
    {
        private readonly Dictionary<Type, InstanceGenerationDefinition> _instanceGenerationDefinitionsStore = new();

        public DataGenerator AddInstanceGenerator<T>(
            Func<T> instanceGenerationAction,
            Func<T>? emptyInstanceGenerationAction = null,
            Func<int, T>? multipleInstancesGenerationAction = null)
            where T : class
        {
            if (instanceGenerationAction is null)
            {
                throw new ArgumentNullException(nameof(instanceGenerationAction));
            }

            var instanceGenerationDefinition = new InstanceGenerationDefinition(
                instanceGenerationAction,
                emptyInstanceGenerationAction ?? Activator.CreateInstance<T>,
                multipleInstancesGenerationAction);

            if (!_instanceGenerationDefinitionsStore.ContainsKey(typeof(T)))
            {
                _instanceGenerationDefinitionsStore.Add(typeof(T), instanceGenerationDefinition);
            }
            else
            {
                _instanceGenerationDefinitionsStore[typeof(T)] = instanceGenerationDefinition;
            }

            return this;
        }

        public T GenerateInstance<T>(Action<T>? instanceConfigurationAction = null) where T : class
        {
            var instance = ((Func<T>)GetInstanceGenerationDefinition<T>().InstanceGenerationAction).Invoke();
            instanceConfigurationAction?.Invoke(instance);

            return instance;
        }

        public T GenerateEmptyInstance<T>(Action<T>? instanceConfigurationAction = null) where T : class, new()
        {
            var instance = ((Func<T>)GetInstanceGenerationDefinition<T>().EmptyInstanceGenerationAction).Invoke();
            instanceConfigurationAction?.Invoke(instance);

            return instance;
        }

        public ICollection<T> GenerateInstances<T>(int count) where T : class
        {
            var instanceGenerationDefinition = GetInstanceGenerationDefinition<T>();
            var instances = new List<T>();

            for (var i = 0; i < count; i++)
            {
                instances.Add(
                    (instanceGenerationDefinition.MultipleInstancesGenerationAction as Func<int, T>)?.Invoke(i)
                    ?? ((Func<T>)instanceGenerationDefinition.InstanceGenerationAction).Invoke());
            }

            return instances;
        }

        private InstanceGenerationDefinition GetInstanceGenerationDefinition<T>() where T : class
        {
            if (!_instanceGenerationDefinitionsStore.TryGetValue(typeof(T), out var instanceGenerationDefinition))
            {
                throw new InvalidOperationException($"Type generator has not been registered for type '{typeof(T).Name}'.");
            }

            return instanceGenerationDefinition;
        }

        private record InstanceGenerationDefinition(
            Func<object> InstanceGenerationAction,
            Func<object> EmptyInstanceGenerationAction,
            Func<int, object>? MultipleInstancesGenerationAction);
    }