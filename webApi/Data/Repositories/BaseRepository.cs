using webApi.Data.Entities;
using webApi.Data.Interfaces;

namespace webApi.Data.Repositories 
{
    public class BaseRepository
    {   
        public NewsContext Context = new NewsContext();
    }
}