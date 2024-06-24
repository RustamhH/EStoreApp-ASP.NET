using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Domain.Dtos
{
    public class TokenDTO
    {
        public string? Token { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
