using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace RacasDeCachorros.Models
{
    public class Cachorro
    {
        [HiddenInput]
        public int CachorroId { get; set; }

        public string? Nome { get; set; }
        public string? Origem { get; set; }
        public string? Tamanho { get; set; }
        public string? Grupo { get; set; }
        public DateTime Nascimento { get; set; }

        [Display(Name = "Gênero")]
        public Genero? Genero { get; set; }
    }

    public enum Genero
    {
        Macho, Femea
    }
}
