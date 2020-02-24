using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }

        public static string GetDefaultImage()
        {
            return "http://www.clker.com/cliparts/d/9/8/e/144992008112017272761813__300x300_award_best_broadband_gold_trophy-th.png";
        }

        public override string ToString()
        {
            return $"ID: {Id}. Title: {Title}.";
        }

    }
}
