using System.Data;

namespace PackagePlanner.Models
{
    public class Config
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Config(DataRow row)
        {
            Name = (string)row[0];
            Value = (string)row[1];
        }
    }
}