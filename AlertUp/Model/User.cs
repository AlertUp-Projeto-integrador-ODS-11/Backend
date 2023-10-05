using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlertUp.Model;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column(TypeName = "varchar")]
    [StringLength(70)]
    public string Nome { get; set; } = string.Empty;

    [Column(TypeName = "varchar")]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(100)]
    public string Senha { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(5000)]
    public string Foto { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(255)]
    public string Municipio { get; set; } = string.Empty;
    
    [InverseProperty("User")]
    public virtual ICollection<Postagem>? Postagem { get; set; } = new List<Postagem>();
}