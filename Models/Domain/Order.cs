using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace recipeapp_backend.Models
{
    public class Order
    {
        [Key]   
        public int OrderId { get; set; }
        public string OrderStep { get; set; }
        public Recipes Recipes { get; set; }

    }
}