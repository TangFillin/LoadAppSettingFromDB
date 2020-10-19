using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace LoadAppSettingFromDB.ConfigurationSet
{
    [Table("SYSTEMCONFIG")]
    public class SystemConfig
    {
        [Key]
        [Column("SYSTEMCONFIGID")]
        public int Id { get; set; }
        [Column("KEY")]
        public string Key { get; set; }
        [Column("VALUE")]
        public string Value { get; set; }
        [Column("VALUETYPE")]
        public int? ValueType { get; set; }
        [Column("DEFVALUE")]
        public string DefValue { get; set; }
        [Column("ISSYSTEM")]
        public bool? IsSystem { get; set; }
    }
}