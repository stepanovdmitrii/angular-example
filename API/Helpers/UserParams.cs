using System;

namespace API.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 10;

        public int PageNumber {get; set;} = 1;
        public int PageSize {
            get => _pageSize;
            set => _pageSize = Math.Min(value, MaxPageSize);
        }

        public string CurrentUsername {get;set;}
        public string Gender {get; set;}
        public int MinAge {get; set;} = 18;
        public int MaxAge {get; set;} = 150;
        public string OrderBy {get; set;} = "lastActive";
    }
}