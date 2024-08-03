using Domain.Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string ElaborationType { get; set; } // ("Elaborado a mano" o "Elaborado a mano y máquina")

    [Required]
    public string ProductName { get; set; }

    // Relación con la tabla ProductStates
    [ForeignKey("ProductState")]
    public int ProductStateId { get; set; }

    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }

    // Propiedad de navegación para la relación con ProductStates
    public ProductStates? ProductState { get; set; }
}

