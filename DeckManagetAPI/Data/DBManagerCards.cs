using DeckManagerAPI.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DeckManagerAPI.Data
{
    public class DBManagerCards
    {
        private string JsonFilePath; 
        private List<Card>? dataCards; 

        public DBManagerCards()
        {
            JsonFilePath = Directory.GetCurrentDirectory() + "\\Data\\dataCards.json";
            LoadCards();
        }

        private void LoadCards()
        {
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string jsonContent = File.ReadAllText(JsonFilePath);
                    dataCards = JsonSerializer.Deserialize<List<Card>>(jsonContent);
                }
                else
                {
                    dataCards = new List<Card>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar as cartas: {ex.Message}");
                dataCards = new List<Card>();
            }
        }

        public void SaveCards()
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(dataCards);

                File.WriteAllText(JsonFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar as cartas: {ex.Message}");
            }
        }

        public void AddCard(Card card)
        {
            card.Id = GetNextId();
            dataCards.Add(card);
            SaveCards();
        }

        public void UpdateCard(Card card)
        {
            Card existingCard = dataCards.FirstOrDefault(c => c.Id == card.Id);
            if (existingCard != null)
            {
                existingCard.Name = card.Name;
                existingCard.Power = card.Power;
                existingCard.Toughness = card.Toughness;
                SaveCards();
            }
        }

        public void DeleteCard(int cardId)
        {
            Card cardToDelete = dataCards.FirstOrDefault(c => c.Id == cardId);
            if (cardToDelete != null)
            {
                dataCards.Remove(cardToDelete);
                SaveCards();
            }
        }

        public List<Card> GetAllCards()
        {
            return dataCards;
        }

        public Card GetCard(int id)
        {
            return dataCards.FirstOrDefault(c => c.Id == id);
        }

        private int GetNextId()
        {
            int maxId = dataCards.Count > 0 ? dataCards.Max(c => c.Id) : 0;
            return maxId + 1;
        }
    }

}
