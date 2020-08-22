using System.Runtime.Serialization;
using ToeKnife.Common.Transport;

namespace ToeKnife.Common.Shell.Documents
{
    public class DocumentPointer : SerialisedObject
    {
        public string FileName
        {
            get => this.Get<string>("FileName");
            set => this.Set("FileName", value);
        }

        public DocumentPointer(string name) : base(name)
        {
        }

        protected DocumentPointer(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
