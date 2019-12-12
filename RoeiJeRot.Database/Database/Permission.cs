using System.ComponentModel.DataAnnotations.Schema;

namespace RoeiJeRot.Database.Database
{
    [Table("permissions")]
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}