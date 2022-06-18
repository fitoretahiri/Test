using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_delivery_app_LabCouse1.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
