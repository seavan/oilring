using System.Collections.Generic;
using System;

namespace Common.Security
{
    [Serializable]
    public class TicketUserData
    {
        public List<string> Roles { get; set; }

        public long UserId { get; set; }

        public string Login { get; set; }
    }
}