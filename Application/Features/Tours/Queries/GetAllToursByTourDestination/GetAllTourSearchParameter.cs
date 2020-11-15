using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Tours.Queries.GetAllTours
{
    public class GetAllTourSearchParameter
    {
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public string UserId { get; set; }
    }
}
