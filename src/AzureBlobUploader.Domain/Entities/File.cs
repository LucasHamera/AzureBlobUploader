using System.Diagnostics.CodeAnalysis;
using AzureBlobUploader.Domain.ValueObjects;

namespace AzureBlobUploader.Domain.Entities
{
    public class File
    {
        public File(
            [NotNull] FileName name,
            [NotNull] FileAddress address
        )
        {
            Name = name.Name;
            Address = address.Address;
        }

        public string Name
        {
            get;
        }

        public string Address
        {
            get;
        }
    }
}
