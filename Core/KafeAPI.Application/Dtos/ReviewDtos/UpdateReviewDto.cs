using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeAPI.Application.Dtos.ReviewDtos
{
    public class UpdateReviewDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // 1 ile 5 arasında değer validator eklenecek.
        public DateTime CreatedAt { get; set; }
    }
}
