using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Api.FlashScope
{
    public interface IFlashService
    {
        void Set(string key, string value);

        string Get(string key);
    }
}
