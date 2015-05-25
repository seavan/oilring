using System;

namespace Web.Common.Models
{
    public class PagerModel
    {
        public PagerModel(long _rowsCount, long _pagesCount, long _currentPage, string _moduleId, Type _modelType, int _maxPages = 7, int _round = 3)
        {
            RowsCount = _rowsCount;
            PageCount = _pagesCount;
            CurrentPage = _currentPage;
            ModelType = _modelType;
            MaxPages = _maxPages;
            Round = _round;
            ModuleId = _moduleId;
        }

        public string ModuleId { get; set; }
        public long RowsCount { get; set; }
        public long PageCount { get; set; }
        public long CurrentPage { get; set; }
        public long MaxPages { get; set; }
        public long Round { get; set; }
        public Type ModelType { get; set; }
    }
}