using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Task2Flowers.Exceptions;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public abstract class Service<T> : IService<T>
    {
        protected readonly IStorage<T> _storage;

        public Service(IStorage<T> storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public virtual async Task AddAsync(T element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            await _storage.AddAsynс(element);
        }

        public async virtual Task<T> GetAsynс(int id)
        {
            var element = await _storage.GetAsynс(id);
            return element;
        }

        public async virtual Task<IReadOnlyCollection<T>> GetAllAsynс()
        {
            var elements = await _storage.GetAllAsynс();
            return elements;
        }
        public async virtual Task<int> GetCurrentIdGeneratorValueAsync()
        {
            var idGenerator = await _storage.IdGenerator();
            return idGenerator.GetCurrentValue();
        }

        protected virtual void Validation<DTO>(DTO obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(obj, new ValidationContext(obj), validationResults))
            {
                throw new ValidationResultsException(validationResults);

            }
        }
    }
}
