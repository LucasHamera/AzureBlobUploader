using System.Text.RegularExpressions;
using AzureBlobUploader.Domain.ValueObjects.Exceptions;

namespace AzureBlobUploader.Domain.ValueObjects
{
    public class FileAddress
    {
        // source: https://stackoverflow.com/questions/3809401/what-is-a-good-regular-expression-to-match-a-url
        private const string UrlPattern =
           @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";

        public FileAddress(
            string address
        )
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new BlankFileAddressException();

            if (!CheckAddress(address))
                throw new InvalidFileAddressException();

            Address = address;
        }

        public string Address
        {
            get;
        }

        private bool CheckAddress(
            string address
        )
        {
            return Regex.IsMatch(address, UrlPattern);
        }
    }
}
