using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Api.Messages
{
    public interface IMessageIntegrity
    {
        string Encode(string key);

        bool Verify(string encodedKey);
    }
}
