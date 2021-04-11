using System;
using System.Collections.Generic;
using System.Text;

namespace CadastraCaminhao.Shared.Extensions
{
    public static class ExtensionString
    {
        public static bool IsGuid(this string text)
        {
            bool isGuid = Guid.TryParse(text, out _);

            return isGuid;
        }
    }
}
