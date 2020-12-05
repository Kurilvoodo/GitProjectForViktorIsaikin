using System.Collections.Generic;

namespace Rokolabs.Task5.ThreeLayerLibrary.Entities
{
    public class PageResult<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string _partAuthorName { get; set; }
        public string _sortString { get; set; }
        public string _partTitle { get; set; }
    }
}