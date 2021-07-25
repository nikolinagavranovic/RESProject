using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelPodataka.DataModel
{
    [DataContract]
    public class Resource
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name  { get; set; }
        [DataMember]
        public string Description  { get; set; }
        [DataMember]
        public ResourceType Type  { get; set; }

        public Resource() 
        {

        }

        public Resource(int id, string name, string description, ResourceType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Type?.ToString()}";
        }
    }
}
