﻿namespace RareBirdsApi.Models.DTOs
{
    public class GETBirdsDTO
    {
        public int Id { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        public string Rarity { get; set; }
    }
}