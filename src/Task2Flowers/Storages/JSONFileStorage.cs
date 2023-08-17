using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Task2Flowers.Entities;
using Task2Flowers.Generators;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Storages
{
    public class JSONFileStorage<T> : IStorage<T>
        where T : Entity
    {
        private readonly String _filename;
        private readonly ILogger _logger;

        public JSONFileStorage(string filename, ILogger<JSONFileStorage<T>> logger)
        {
            _filename = filename;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsynс()
        {
            return await this.ReadFileAsync();
        }

        public async Task AddAsynс(T element)
        {
            var elements = await this.ReadFileAsync();
            elements.Add(element);

            _logger.LogInformation("An object {@Element} added to the collection [{CollectionType}]", element, typeof(T).Name);

            await this.WriteFileAsync(elements);

        }

        public async Task<T> GetAsynс(int id)
        {
            var elements = await this.ReadFileAsync();
            var list = elements.ToList();

            return list.Find(element => element.Id == id);
        }

        public async Task<IntIdGenerator> IdGenerator()
        {
            var elements = await this.ReadFileAsync();
            var elementsList = elements.ToList();

            var initialValue = elementsList.Any()
                                ? elementsList.Select(e => e.Id).Max() + 1
                                : 0;

            return new IntIdGenerator(initialValue);
        }

        private async Task<HashSet<T>> ReadFileAsync()
        {
            HashSet<T> collection = null;
             
            try
            {
                using var fs = new FileStream($"{_filename}.json", FileMode.OpenOrCreate);

                fs.Seek(0, SeekOrigin.Begin);
                collection = await JsonSerializer.DeserializeAsync<HashSet<T>>(fs);
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex, "An exception occured during reading the file {Filename}.", _filename);
            }

            return collection ?? new HashSet<T>();
        }
        
        private async Task WriteFileAsync(ICollection<T> elements)
        {
            using(FileStream fs = new FileStream($"{_filename}.json", FileMode.Truncate))
            {
                fs.Seek(0, SeekOrigin.Begin);

                await JsonSerializer.SerializeAsync<ICollection<T>>(fs, elements);
            }
        }
    }
}
