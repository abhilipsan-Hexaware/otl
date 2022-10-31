using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace logging.Contracts.DTO {
   public class DocumentDto { 
     public string Id { get; set; }
        public string Name { get; set; } 
        public string Address { get; set; } 
} 
}
