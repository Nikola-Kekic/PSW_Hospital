using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
