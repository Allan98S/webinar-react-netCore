using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesApiFull.Entities
{
    [Table("heroes")]
    public class HeroeEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_heroe", Order = 1)]
        [Key]
        public long? IdHeroe { get; set; }

        [Required(ErrorMessage = "El nombre del heroe es requerido.")]
        [MaxLength(50, ErrorMessage = "El nombre no debe ser mayor a 50 caracteres.")]
        [Column("name", Order = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El poder del heroe es requerido.")]
        [MaxLength(100, ErrorMessage = "El poder no debe ser mayor a 100 caracteres.")]
        [Column("power", Order = 3)]
        public string Power { get; set; }

        [Required(ErrorMessage = "El nombre del heroe es requerido.")]
        [MaxLength(50, ErrorMessage = "El nombre no debe ser mayor a 50 caracteres.")]
        [Column("company", Order = 4)]
        public string Company { get; set; }

        [Required(ErrorMessage = "El estado del heroe es requerido.")]
        [Column("status", Order = 5)]
        public bool? IsAlive { get; set; }
    }
}
