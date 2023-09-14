using DeckManagerAPI.Entities;
using System.Text.Json;

namespace DeckManagerAPI.Data
{
    public class DBManagerPlayers
    {
        private string JsonFilePath;
        private List<Player>? dataPlayers;

        public DBManagerPlayers()
        {
            JsonFilePath = Directory.GetCurrentDirectory() + "\\Data\\dataPlayers.json";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string jsonContent = File.ReadAllText(JsonFilePath);
                    dataPlayers = JsonSerializer.Deserialize<List<Player>>(jsonContent);
                }
                else
                {
                    dataPlayers = new List<Player>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar os jogadores: {ex.Message}");
                dataPlayers = new List<Player>();
            }
        }

        public void SaveData()
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(dataPlayers);

                File.WriteAllText(JsonFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar aos jogadores: {ex.Message}");
            }
        }

        public void AddPlayer(Player player)
        {
            player.Id = GetNextId();
            dataPlayers.Add(player);
            SaveData();
        }

        public void UpdatePlayer(Player player)
        {
            Player existingPlayer = dataPlayers.FirstOrDefault(c => c.Id == player.Id);
            if (existingPlayer != null)
            {
                dataPlayers[dataPlayers.IndexOf(existingPlayer)] = player;
                SaveData();
            }
        }

        public void DeletePlayer(int id)
        {
            Player playerToDelete = dataPlayers.FirstOrDefault(c => c.Id == id);
            if (playerToDelete != null)
            {
                dataPlayers.Remove(playerToDelete);
                SaveData();
            }
        }

        public Player GetPlayer(string login)
        {
            return dataPlayers.FirstOrDefault(c => c.Login == login);
        }

        public List<Player> GetAllPlayers()
        {
            return dataPlayers;
        }

        private int GetNextId()
        {
            int maxId = dataPlayers.Count > 0 ? dataPlayers.Max(c => c.Id) : 0;
            return maxId + 1;
        }
    }
}
