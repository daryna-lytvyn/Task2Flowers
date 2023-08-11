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

        public JSONFileStorage(string filename)
        {
            _filename = filename;
        }

        public async Task CopyFileAsync(string filename)
        {
            var elements = await this.ReadFileAsync();
            using (var fs = new FileStream($"{filename}.json", FileMode.OpenOrCreate))
            {
                fs.Seek(0, SeekOrigin.Begin);

                await JsonSerializer.SerializeAsync<ICollection<T>>(fs, elements);
            }
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsynс()
        {
            var elements = await this.ReadFileAsync();

            return elements != null ? elements.ToList() : new List<T>();
        }

        public async Task AddAsynс(T element)
        {
            var elements = await this.ReadFileAsync();
            elements.Add(element);

            await this.WriteInFolowingFileAsync(elements);
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
            elements.ToList();
            var initialValue = elements.Any() 
                                ? elements.Select(e => e.Id).Max()+1
                                : 0;

            return new IntIdGenerator(initialValue);
        }

        private async Task<ICollection<T>> ReadFileAsync()
        {
            try
            {
                using (FileStream fs = new FileStream($"{_filename}.json", FileMode.OpenOrCreate))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    var elements = await JsonSerializer.DeserializeAsync<ICollection<T>>(fs);

                    return elements;
                }
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        private async Task WriteInFolowingFileAsync(ICollection<T> elements)
        {
            using (FileStream fs = new FileStream($"{_filename}.json", FileMode.Truncate))
            {
                fs.Seek(0, SeekOrigin.Begin);

                await JsonSerializer.SerializeAsync<ICollection<T>>(fs, elements);
            }
        }
    }
}
