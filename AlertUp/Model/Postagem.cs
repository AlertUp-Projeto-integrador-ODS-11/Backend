using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AlertUp.Model;

public class Postagem : Auditable
{
    [Key] //PrimaryKey (Id)
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //AutoIncrement
    public long Id { get; set; }
    
    [Column(TypeName = "varchar")]
    [StringLength(100)]
    public string Titulo { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(1000)]
    public string Descricao { get; set; } = string.Empty;
    
    [Column(TypeName = "bigint")]
    public long? Relevancia { get; set; }
    
    [Column(TypeName = "varchar")]
    [StringLength(5000)]
    public string Foto { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(100)]
    public string Municipio { get; set; } = string.Empty;
    
    public virtual Tema? Tema { get; set; }
    public virtual User? User { get; set; }
}