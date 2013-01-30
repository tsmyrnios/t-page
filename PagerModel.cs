using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shared
{
    public class PagerModel
    {
        public PagerModel()
        {
            PageIndex = 0;
            PageSize = 10;
            PageGroupSize = 10;
            TotalRowCount = 0;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalRowCount { get; set; }
        public int PageGroupSize { get; set; }

        public int PageNumber { get { return PageIndex + 1; } }

        public int StartRowIndex { get { return Math.Max(0, PageIndex) * PageSize; } }
        public int EndRowIndex { get { return Math.Max(0, Math.Min(StartRowIndex + PageSize, TotalRowCount - 1)); } }
        public int StartRowNumber { get { return StartRowIndex + 1; } }
        public int EndRowNumber { get { return EndRowIndex + 1; } }

        public int PageCount { get { return (TotalRowCount == 0 || PageSize == 0) ? 0 : (int)Math.Ceiling((decimal)TotalRowCount / (decimal)PageSize); } }
        public bool IsFirstPage { get { return PageCount > 0 && PageIndex == 0; } }
        public bool IsLastPage { get { return PageIndex == PageCount - 1; } }

        public int PageGroupCount { get { return (PageCount == 0 || PageGroupSize == 0) ? 0 : (int)Math.Ceiling((decimal)PageCount / (decimal)PageGroupSize); } }
        public int PageGroupPageCount { get { return Math.Min(PageGroupSize, PageCount - (PageGroupIndex * PageGroupSize)); } }
        public int PageGroupIndex { get { return (PageIndex == 0 || PageGroupSize == 0) ? 0 : (int)Math.Floor((decimal)PageIndex / (decimal)PageGroupSize); } }
        public bool IsFirstPageGroup { get { return PageGroupCount > 0 && PageGroupIndex == 0; } }
        public bool IsLastPageGroup { get { return PageGroupIndex == PageGroupCount - 1; } }
        public IEnumerable<int> PageIndices
        {
            get
            {
                var pageIndices = new List<int>();
                var startingPageIndex = PageGroupIndex * PageGroupSize;
                for (var i = 0; i < PageGroupPageCount; i++)
                    pageIndices.Add(startingPageIndex + i);
                return pageIndices;
            }
        }
        public IEnumerable<int> PageNumbers { get { return PageIndices.Select(p => p + 1).ToList(); } }
    }
}