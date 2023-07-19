using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public virtual void Add(T element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            _storage.Add(element);
        }

        public virtual T Get(int id)
        {
            return _storage.Get(id);
        }

        public virtual IReadOnlyCollection<T> GetAll()
        {
            return _storage.GetAll();
        }
        public virtual int GetCurrentIdGeneratorValue()
        {
            return _storage.IdGenerator().GetCurrentValue();
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
