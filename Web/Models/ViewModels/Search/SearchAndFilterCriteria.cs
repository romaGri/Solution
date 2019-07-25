using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ViewModels.Search
{
    public class SearchAndFilterCriteria
    {
        public int? SelectedForumId { get; set; }
        public string SearchText { get; set; }
        public Range<long?> Size { get; set; }
        public Range<DateTime?> Date { get; set; }

        public SearchAndFilterCriteria()
        {
            Size = new Range<long?>();
            Date = new Range<DateTime?>();
        }
    }
    public class Range<T>
    {
        public T From { get; set; }
        public T To { get; set; }
    }

}
