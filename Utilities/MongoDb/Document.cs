using MongoDB.Bson;

namespace Utilities.MongoDb
{
    public class Document: IDocument
    {
        public ObjectId Id { get; set; }
    }
}
