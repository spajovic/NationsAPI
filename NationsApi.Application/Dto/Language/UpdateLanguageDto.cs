using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Language
{
    public class UpdateLanguageDto : AddLanguageDto
    {
        public int Id { get; set; }
    }
}
