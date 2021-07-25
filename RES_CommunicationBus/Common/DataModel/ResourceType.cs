using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelPodataka.DataModel
{
    [DataContract]
    public class ResourceType
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public ResourceType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ResourceType()
        {

        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
