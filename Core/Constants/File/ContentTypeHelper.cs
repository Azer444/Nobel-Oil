using System.Collections.Generic;

namespace EcomLab.Core.Constants.File
{
    public struct ContentTypeHelper
    {
        public static List<string> Images { get; } = new List<string> { "image/jpg", "image/jpeg", "image/png", "image/heic", "image/svg+xml" };
        public static List<string> PDF { get; } = new List<string> { "application/pdf" };
    }
}
