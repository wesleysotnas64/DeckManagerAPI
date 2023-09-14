using DeckManagerAPI.Entities;
using System.Text.Json;

namespace DeckManagerAPI.Data
{
    public class DBManagerAdministrators
    {
        private string JsonFilePath;
        private List<Administrator>? dataAdministrators;

        public DBManagerAdministrators()
        {
            JsonFilePath = Directory.GetCurrentDirectory() + "\\Data\\dataAdministrators.json";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string jsonContent = File.ReadAllText(JsonFilePath);
                    dataAdministrators = JsonSerializer.Deserialize<List<Administrator>>(jsonContent);
                }
                else
                {
                    dataAdministrators = new List<Administrator>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar os administradores: {ex.Message}");
                dataAdministrators = new List<Administrator>();
            }
        }

        public void SaveData()
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(dataAdministrators);

                File.WriteAllText(JsonFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar aos administradores: {ex.Message}");
            }
        }

        public void AddAdministrator(Administrator administrator)
        {
            administrator.Id = GetNextId();
            dataAdministrators.Add(administrator);
            SaveData();
        }

        public void UpdateAdministrator(Administrator administrator)
        {
            Administrator existingAdministrator = dataAdministrators.FirstOrDefault(c => c.Id == administrator.Id);
            if (existingAdministrator != null)
            {
                dataAdministrators[dataAdministrators.IndexOf(existingAdministrator)] = administrator;
                SaveData();
            }
        }

        public void DeleteAdministrator(int id)
        {
            Administrator administratorToDelete = dataAdministrators.FirstOrDefault(c => c.Id == id);
            if (administratorToDelete != null)
            {
                dataAdministrators.Remove(administratorToDelete);
                SaveData();
            }
        }

        public Administrator GetAdministrator(string login)
        {
            return dataAdministrators.FirstOrDefault(c => c.Login == login);
        }

        public List<Administrator> GetAllAdministrators()
        {
            return dataAdministrators;
        }

        private int GetNextId()
        {
            int maxId = dataAdministrators.Count > 0 ? dataAdministrators.Max(c => c.Id) : 0;
            return maxId + 1;
        }
    }
}
